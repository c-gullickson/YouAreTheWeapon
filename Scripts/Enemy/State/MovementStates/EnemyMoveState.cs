using Constants;
using Enemy.Controller;
using UnityEngine;

namespace Enemy.State.MovementStates
{
    public abstract class EnemyMoveState: EnemyState
    {
        
        protected Vector3 _startPos;
        protected Vector3 _targetPos;

        protected EnemyMovementPattern _movementPattern;
        protected float _speed;
        protected float _amplitude;
        protected float _frequency;
        
        protected float elapsedTime;
        protected float _distanceToTarget;
        
        protected EnemyMoveState(EnemyController enemyController) : base(enemyController)
        {
            _speed = _enemyController.EnemyConfiguration.MovementSpeed;

            _movementPattern = _enemyController.EnemyConfiguration.MovementPattern;
            _amplitude = _enemyController.EnemyConfiguration.Amplitude;
            _frequency = _enemyController.EnemyConfiguration.Frequency;
            
            Debug.Log("Enemy Move State Constructor");
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
            
            // Calculate the distance to the target, and if the target is within attack range, then change to an attack state
            _distanceToTarget = CalculateDistanceToTarget(_enemyController.transform.position, _targetPos);
            if (_distanceToTarget < _enemyController.EnemyConfiguration.AttackRange)
            {
                _enemyController.TransitionToState(EnemyAttackFactory.CreateEnemyAttackState(_enemyController));
            }
        }
        
        public virtual float CalculateDistanceToTarget(Vector3 startPosition, Vector3 targetPosition)
        {
            return Vector3.Distance(startPosition, targetPosition);
        }
    }
}