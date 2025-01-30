using Enemy.Controller;
using UnityEngine;

namespace Enemy.State.AttackStates
{
    public abstract class EnemyAttackState: EnemyState
    {
        protected EnemyAttackState(EnemyController enemyController) : base(enemyController)
        {
            
        }
        
        public override void Enter()
        {
            Debug.Log($"Enter Enemy Attack State:");
        }
        
        public override void Update()
        {

        }
        
        public override void Exit()
        {

        }
    }
}