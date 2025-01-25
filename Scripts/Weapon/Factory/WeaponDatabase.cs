using ScriptableObjects;

namespace Weapon.Factory
{
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class WeaponDatabase : MonoBehaviour
    {
        private static Dictionary<string, WeaponConfiguration_ScriptableObject> weaponConfigs = new Dictionary<string, WeaponConfiguration_ScriptableObject>();

        public static async Task Initialize()
        {
            var handle = Addressables.LoadAssetsAsync<WeaponConfiguration_ScriptableObject>("WeaponAssets", weapon =>
            {
                if (!weaponConfigs.ContainsKey(weapon.WeaponName))
                    weaponConfigs[weapon.WeaponName] = weapon;
            });

            await handle.Task;
        }

        public static WeaponConfiguration_ScriptableObject GetWeaponByName(string weaponName)
        {
            return weaponConfigs.TryGetValue(weaponName, out var weapon) ? weapon : null;
        }
    }

}