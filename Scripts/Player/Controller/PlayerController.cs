using System;
using System.Collections.Generic;
using Constants;
using Managers;
using Models.Interfaces;
using Player.Component;
using ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;
using UserInterface.PlayerHud;
using Weapon.Factory;

namespace Player.Controller
{
    [RequireComponent(typeof(LineRenderer))]
    public class PlayerController : MonoBehaviour, IDamagable
    {
        [SerializeField] private GameObject _playerBarrelMesh;
        [SerializeField] private StatConfiguration_ScriptableObject _statConfiguration_ScriptableObject;
        [SerializeField] private PlayerStats_UserInterface _playerStats_UserInterface;
        
        [SerializeField] private LineRenderer _lineRenderer;
        
        private Transform _turretFirePoint = null;
        
        protected IPlayerRotation _playerRotation = null;
        protected IShooting _playerShooting = null;
        protected IStatistics _playerStats = null;
        
        private void Awake()
        {
            // Add a rotation component
            _playerRotation = new PlayerRotation(_playerBarrelMesh);
            
            // Add a shooting component
            _turretFirePoint = _playerBarrelMesh.transform.Find("SM_Bld_Planetarty_Cannon_01_ShootPoint");
            _playerShooting = new PlayerShooting(_turretFirePoint);
            
            // Add a stats UI component
            _playerStats = new PlayerStats(_playerStats_UserInterface);
            _playerStats.Initialize(_statConfiguration_ScriptableObject);
            _playerStats.OnStatZero += Statistics_OnStatZero;
        }

        private void Update()
        {
            _playerRotation?.RotatePlayer();
            _playerShooting?.UpdateState();

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Create a new instance of a weapon
                Debug.Log("Equip New Weapon: Alpha 1");
                var weapon = WeaponFactory.CreateWeaponController("SimpleLaser_ScriptableObject");
                weapon.Initialize(_lineRenderer, _turretFirePoint );
                
                _playerShooting?.EquipWeapon(weapon);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // Create a new instance of a weapon
                Debug.Log("Equip New Weapon: Alpha 2");
                var weapon = WeaponFactory.CreateWeaponController("WideLaser_ScriptableObject");
                weapon.Initialize(_lineRenderer, _turretFirePoint );
                
                _playerShooting?.EquipWeapon(weapon);
            }
        }

        /// <summary>
        /// Allow for the player to take damage
        /// </summary>
        public void Damage(StatType statType, float damage)
        {
            Debug.Log("Damange Player Controller");
            Dictionary<StatType, float> _stats = new Dictionary<StatType, float>();
            _stats.Add(statType, damage);
            
            _playerStats.ModifyStat(_stats);
        }
        
        /// <summary>
        /// Allow for the player to take damage
        /// </summary>
        public void Heal()
        {
            Debug.Log("Heal Player Controller");
            Dictionary<StatType, float> _stats = new Dictionary<StatType, float>();
            _stats.Add(StatType.Health, 10);
            
            _playerStats.ModifyStat(_stats);
        }
        
        /// <summary>
        /// Listen for when certain stats hit zero
        /// </summary>
        /// <param name="statType"></param>
        private void Statistics_OnStatZero(StatType statType)
        {
            switch (statType)
            {
                case StatType.Health:
                    Destroy(this.gameObject);
                    LevelManager.Instance.GameOver(false);
                    break;
                case StatType.Armor:
                    break;
                case StatType.Shield:
                    break;
                default:
                    Debug.LogError($"Unknown stat type: {statType}");
                    break;
            }
        }
    }
}