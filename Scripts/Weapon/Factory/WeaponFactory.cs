using ScriptableObjects;
using UnityEngine;
using Weapon.ConcreteClasses;
using Weapon.Controller;

namespace Weapon.Factory
{
    public static class WeaponFactory
    {
        public static WeaponController CreateWeaponController(string weaponName)
        {
            // Get the WeaponConfig from the database
            var weaponConfiguration = WeaponDatabase.GetWeaponByName(weaponName);
            if (weaponConfiguration == null)
            {
                Debug.LogError($"Weapon {weaponName} not found in the database!");
                return null;
            }
            
            // TODO: Should this create a game object instead of a class?
            return new SimpleLaser(weaponConfiguration);
        }
    }
}