using Player.Component;
using UnityEngine;

namespace Player.State.WeaponState
{
    public class WeaponShootState : WeaponBaseState
    {
        private IShooting _shooting;
        public WeaponShootState(IShooting shooting) : base(shooting)
        {
            _shooting = shooting;
        }

        public override void Enter()
        {
            Debug.Log("Enter Weapon Shoot State");
            /// If cooldown between shots then transition out, Otherwise, listen for another shoot
            /// Transition to a reload state?
            /// Transition back to Idle State?
        }

        public override void Update()
        {
            if (_shooting?._equipWeapon == null) return;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
            
             _shooting._equipWeapon.UpdateLaser();
            
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                StopShoot();
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Weapon Shoot State");
        }
        
        
        private void Shoot()
        {
            Debug.Log("Start Shoot");
            // Vector3 endPoint = _shooting._turretFirePoint.position + _shooting._turretFirePoint.forward * 800f;
            // Debug.DrawLine(_shooting._turretFirePoint.position, endPoint, Color.green, 5f);
            _shooting._equipWeapon.ActivateWeapon();
        }

        private void StopShoot()
        {
            Debug.Log("Stop Shoot");
            _shooting._equipWeapon.DeactivateWeapon();
        }
    }
}