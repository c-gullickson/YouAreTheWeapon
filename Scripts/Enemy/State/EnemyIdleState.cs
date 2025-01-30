using Enemy.Controller;
using Enemy.State.MovementStates;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyIdleState: EnemyState
    {
        public EnemyIdleState(EnemyController enemyController) : base(enemyController)
        {
            
        }

        public override void Enter()
        {
            Debug.Log("Enter Enemy Idle State");
            _enemyController.TransitionToState(EnemyMovementFactory.CreateEnemyMoveState(_enemyController));
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
            Debug.Log("Exit Enemy Idle State");

        }
    }
}