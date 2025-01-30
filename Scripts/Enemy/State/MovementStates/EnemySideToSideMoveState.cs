using Enemy.Controller;
using UnityEngine;

namespace Enemy.State.MovementStates
{
    public class EnemySideToSideMoveState: EnemyMoveState
    {
        private Vector3 velocity = Vector3.zero;

        public EnemySideToSideMoveState(EnemyController enemyController) : base(enemyController)
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
            float sineOffset = Mathf.Sin(Time.time * _frequency) * _amplitude;

            // Smoothly move towards the target position with a sine wave effect
            _enemyController.transform.position = Vector3.SmoothDamp(
                _enemyController.transform.position,
                basePosition + Vector3.right * sineOffset,
                ref velocity,
                0.1f // Adjust smooth time as needed
            );
        }

        public override void Exit()
        {
            Debug.Log("Exit Enemy Move State");
        }
    }
}