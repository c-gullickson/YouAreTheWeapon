using Player.State.WeaponState;
using UnityEngine;
using Weapon.Controller;

namespace Player.Component
{

    public interface IShooting
    {
        WeaponController _equipWeapon { get; set; }
        WeaponBaseState _currentState { get; set; }
        Transform _turretFirePoint { get; set; }
        
        
        
        void TransitionToState(WeaponBaseState newState);
        void UpdateState();

        void EquipWeapon(WeaponController weaponController);
    }
    
    public class PlayerShooting: IShooting
    {
        public WeaponController _equipWeapon { get; set; }
        public WeaponBaseState _currentState { get; set; }
        public Transform _turretFirePoint { get; set; }
        
        
        /// <summary>
        /// Construct the shooting class
        /// </summary>
        /// <param name="turretFirePoint"></param>
        public PlayerShooting(Transform turretFirePoint)
        {
            _turretFirePoint = turretFirePoint;
            _currentState = new WeaponIdleState(this);
        }

        /// <summary>
        /// Transition from one state to the next
        /// </summary>
        /// <param name="newState"></param>
        public void TransitionToState(WeaponBaseState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        /// <summary>
        /// Update the current State during runtime
        /// </summary>
        public void UpdateState()
        {
            _currentState?.Update();
        }

        /// <summary>
        /// Set an active weapon
        /// </summary>
        /// <param name="weaponController"></param>
        public void EquipWeapon(WeaponController weaponController)
        {
            _equipWeapon = weaponController;
            TransitionToState(new WeaponIdleState(this));
        }
    }
}