using Enemy.Controller;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyAttackState: EnemyState
    {
        public EnemyAttackState(EnemyController enemyController) : base(enemyController)
        {
            
        }

        public override void Enter()
        {
            Debug.Log("Enter Enemy Attack State");
        }

        public override void Update()
        {
            // TODO: Need to continue moving towards the player
            // TODO: Need to trigger an attack
        }

        public override void Exit()
        {
            Debug.Log("Exit Enemy Attack State");
        }
    }
}