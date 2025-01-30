using System;
using Constants;
using Enemy.Controller;
using Enemy.State.AttackStates;

namespace Enemy.State
{
    public static class EnemyAttackFactory
    {
        public static EnemyAttackState CreateEnemyAttackState(EnemyController enemyController)
        {
            var enemyAttackType = enemyController.EnemyConfiguration.AttackType;

            switch (enemyAttackType)
            {
                case EnemyAttackType.Bomb:
                    return new EnemyBombAttackState(enemyController);
                case EnemyAttackType.SimpleLaser:
                    return new EnemySimpleLaserState(enemyController);
                case EnemyAttackType.AutoLaser:
                    return new EnemyAutoLaserState(enemyController);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}