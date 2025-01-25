using Player.Component;

namespace Player.State.WeaponState
{
    public abstract class WeaponBaseState
    {
        protected IShooting _shooting;

        public WeaponBaseState(IShooting shooting)
        {
            _shooting = shooting;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}