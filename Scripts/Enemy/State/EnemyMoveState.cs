using Constants;
using Enemy.Controller;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyMoveState : EnemyState
    {
        private Vector3 _startPos;
        private Vector3 _targetPos;
        
        private EnemyMovementPattern _movementPattern = EnemyMovementPattern.SideToSide;
        private float _speed = 12f;
        private float _amplitude = 6f; // Used for SideToSide and VShape
        private float _frequency = 5f; // Used for SideToSide and Circular
        
        private float elapsedTime;
        
        public EnemyMoveState(EnemyController enemyController) : base(enemyController)
        {
            _speed = _enemyController.EnemyConfiguration.MovementSpeed;

            _movementPattern = _enemyController.EnemyConfiguration.MovementPattern;
            _amplitude = _enemyController.EnemyConfiguration.Amplitude;
            _frequency = _enemyController.EnemyConfiguration.Frequency;
        }

        public override void Enter()
        {
            _startPos = _enemyController.transform.position;
            _targetPos = _enemyController._targetPosition;
            Debug.Log($"Enter Enemy Move State: Starting At {_startPos}");
        }

        public override void Update()
        {
            elapsedTime += Time.deltaTime;
            
            Vector3 direction = (_targetPos - _startPos).normalized;
            float distanceToTarget = Vector3.Distance(_startPos, _targetPos);

            // If the target is within attack range, then change to an attack state
            if (distanceToTarget < _enemyController.EnemyConfiguration.AttackRange)
            {
                _enemyController.TransitionToState(new EnemyAttackState(_enemyController));
            }
            
            float journeyProgress = Mathf.Clamp01((elapsedTime * _speed) / distanceToTarget);

            // Calculate base forward movement
            Vector3 basePosition = Vector3.Lerp(_startPos, _targetPos, journeyProgress);

            // Apply additional pattern-based movement
            switch (_movementPattern)
            {
                case EnemyMovementPattern.SideToSide:
                    _enemyController.transform.position = basePosition + Vector3.right * Mathf.Sin(elapsedTime * _frequency) * _amplitude;
                    break;
                case EnemyMovementPattern.Circular:
                    _enemyController.transform.position = basePosition + new Vector3(
                        Mathf.Cos(elapsedTime * _frequency) * _amplitude,
                        0f,
                        Mathf.Sin(elapsedTime * _frequency) * _amplitude
                    );
                    break;
                case EnemyMovementPattern.VShaped:
                    _enemyController.transform.position = basePosition + new Vector3(
                        Mathf.Sin(elapsedTime * _frequency) * _amplitude,
                        Mathf.Abs(Mathf.Sin(elapsedTime * _frequency)) * _amplitude,
                        0f
                    );
                    break;
                case EnemyMovementPattern.Forward:
                default:
                    _enemyController.transform.position = basePosition;
                    break;
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Enemy Move State");
        }
    }
}