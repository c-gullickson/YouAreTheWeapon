using Enemy.Controller;

namespace Enemy.State
{
    public abstract class EnemyState
    {
        protected EnemyController _enemyController;

        public EnemyState(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}