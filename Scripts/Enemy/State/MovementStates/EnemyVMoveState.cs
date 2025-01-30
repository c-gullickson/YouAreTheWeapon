using Enemy.Controller;
using UnityEngine;

namespace Enemy.State.MovementStates
{
    public class EnemyVMoveState : EnemyMoveState
    {
       
        public EnemyVMoveState(EnemyController enemyController) : base(enemyController)
        {

        }

        public override void Enter()
        {
            base.Enter();
        }

        /// <summary>
        /// Check the distance between the enemy and the target
        /// If not in range, then continue moveing with the unique movement pattern
        /// </summary>
        public override void Update()
        {
            base.Update();
            
            float journeyProgress = Mathf.Clamp01((elapsedTime * _speed) / _distanceToTarget);

            // Calculate base forward movement
            Vector3 basePosition = Vector3.Lerp(_startPos, _targetPos, journeyProgress);

            // Apply additional pattern-based movement
            _enemyController.transform.position = basePosition + new Vector3(
                Mathf.Sin(elapsedTime * _frequency) * _amplitude,
                Mathf.Abs(Mathf.Sin(elapsedTime * _frequency)) * _amplitude,
                0f
            );
        }

        public override void Exit()
        {
            Debug.Log("Exit Enemy Move State");
        }
    }
}