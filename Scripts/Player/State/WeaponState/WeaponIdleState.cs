using Player.Component;
using UnityEngine;

namespace Player.State.WeaponState
{
    public class WeaponIdleState: WeaponBaseState
    {
        private IShooting _shooting;
        public WeaponIdleState(IShooting shooting) : base(shooting)
        {
            _shooting = shooting;
        }

        public override void Enter()
        {
            Debug.Log("Enter Weapon Idle State");
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _shooting.TransitionToState(new WeaponShootState(_shooting));
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Weapon Idle State");
        }
    }
}