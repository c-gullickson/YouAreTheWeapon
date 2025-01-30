using System;
using Constants;
using Enemy.Controller;
using Enemy.State.MovementStates;

namespace Enemy.State
{
    public static class EnemyMovementFactory
    {
        public static EnemyMoveState CreateEnemyMoveState(EnemyController enemyController)
        {
            var enemyMoveType = enemyController.EnemyConfiguration.MovementPattern;

            switch (enemyMoveType)
            {
                case EnemyMovementPattern.SideToSide:
                    return new EnemySideToSideMoveState(enemyController);
                case EnemyMovementPattern.V:
                    return new EnemyVMoveState(enemyController);
                case EnemyMovementPattern.Circular:
                    return new EnemyCircularMoveState(enemyController);
                case EnemyMovementPattern.Forward:
                    return new EnemyForwardMoveState(enemyController);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}