using Constants;
using Enemy.Controller;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyMoveState : EnemyState
    {
        private Vector3 _startPos;
        private Vector3 _targetPos;
        
        public EnemyMovementPattern movementPattern = EnemyMovementPattern.SideToSide;
        public float speed = 5f;
        public float amplitude = 2f; // Used for SideToSide and VShape
        public float frequency = 1f; // Used for SideToSide and Circular
        
        private float elapsedTime;

        
        public EnemyMoveState(EnemyController enemyController) : base(enemyController)
        {
            
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
            float journeyLength = Vector3.Distance(_startPos, _targetPos);
            float journeyProgress = Mathf.Clamp01((elapsedTime * speed) / journeyLength);

            // Calculate base forward movement
            Vector3 basePosition = Vector3.Lerp(_startPos, _targetPos, journeyProgress);

            // Apply additional pattern-based movement
            switch (movementPattern)
            {
                case EnemyMovementPattern.SideToSide:
                    _enemyController.transform.position = basePosition + Vector3.right * Mathf.Sin(elapsedTime * frequency) * amplitude;
                    break;
                case EnemyMovementPattern.Circular:
                    _enemyController.transform.position = basePosition + new Vector3(
                        Mathf.Cos(elapsedTime * frequency) * amplitude,
                        0f,
                        Mathf.Sin(elapsedTime * frequency) * amplitude
                    );
                    break;
                case EnemyMovementPattern.VShaped:
                    _enemyController.transform.position = basePosition + new Vector3(
                        Mathf.Sin(elapsedTime * frequency) * amplitude,
                        Mathf.Abs(Mathf.Sin(elapsedTime * frequency)) * amplitude,
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