using System;
using UnityEngine;

namespace Weapon.Controller
{
    public abstract class WeaponController 
    {
        public abstract void Initialize(LineRenderer lineRenderer, Transform shootPosition);
        
        public abstract void ActivateWeapon();
        public abstract void DeactivateWeapon();

        
        public virtual void Reload() {}
        
        public virtual void UpdateLaser(){}
    }
}