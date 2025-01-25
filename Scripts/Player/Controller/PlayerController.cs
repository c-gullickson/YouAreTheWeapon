using System;
using System.Collections.Generic;
using Constants;
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
    public class PlayerController : MonoBehaviour
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
            
            /// TODO: Initialize as a HUD component instead of a stats component
            // Add a stats UI component
            _playerStats = new PlayerStats(_playerStats_UserInterface);
            _playerStats.Initialize(_statConfiguration_ScriptableObject);
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
        }
        
    }
}