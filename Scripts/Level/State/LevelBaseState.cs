using Level.Controller;

namespace Level.State
{
    public abstract class LevelBaseState
    {
        protected LevelController _levelController;

        public LevelBaseState(LevelController levelController)
        {
            _levelController = levelController;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}