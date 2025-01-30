using Constants;
using Models.Interfaces;
using ScriptableObjects;
using UnityEngine;
using Weapon.Controller;

namespace Weapon.ConcreteClasses
{
    public class WideLaser: WeaponController
    {
        private WeaponConfiguration_ScriptableObject _weaponConfiguration_ScriptableObject;
        private LineRenderer _lineRenderer;
        private Transform _muzzleTransform;
        
        private LayerMask _layerMask;
        
        public WideLaser(WeaponConfiguration_ScriptableObject weaponConfiguration_ScriptableObject)
        {
            _weaponConfiguration_ScriptableObject = weaponConfiguration_ScriptableObject;
            _layerMask = _weaponConfiguration_ScriptableObject.TargetingLayer;
        }


        public override void Initialize(LineRenderer lineRenderer, Transform muzzleTransform)
        {
            _lineRenderer = lineRenderer;
            _muzzleTransform = muzzleTransform;

            _lineRenderer.startColor = _weaponConfiguration_ScriptableObject.BeamColor;
            _lineRenderer.endColor = _weaponConfiguration_ScriptableObject.BeamColor;
            
            _lineRenderer.startWidth = _weaponConfiguration_ScriptableObject.BeamSize;
            _lineRenderer.endWidth = _weaponConfiguration_ScriptableObject.BeamSize;
            _lineRenderer.textureMode = LineTextureMode.Stretch;
        }

        public override void ActivateWeapon()
        {
            Debug.Log("Simple Laser Shoot");  

            // Perform a raycast to detect where the laser should hit
            RaycastHit hit;
            Vector3 targetPoint = _muzzleTransform.position + _muzzleTransform.forward * _weaponConfiguration_ScriptableObject.Range;

            var laserColliders = Physics.OverlapCapsule(_muzzleTransform.position, targetPoint,
                _weaponConfiguration_ScriptableObject.BeamSize, _layerMask);

            if (laserColliders.Length > 0)
            {
                targetPoint = laserColliders[0].transform.position;
            }
                
            

            // Activate the laser and set positions
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, _muzzleTransform.position); // Start point
            _lineRenderer.SetPosition(1, targetPoint); // End point
        }

        public override void DeactivateWeapon()
        {
            _lineRenderer.enabled = false;
        }

        public override void Reload()
        {
            Debug.Log("Simple Laser Reload");   
        }

        public override void UpdateLaser()
        {
            if (_lineRenderer.enabled)
            {
                // Dynamically update the laser's position
                _lineRenderer.SetPosition(0, _muzzleTransform.position);

                Vector3 targetPoint = _muzzleTransform.position + _muzzleTransform.forward * _weaponConfiguration_ScriptableObject.Range;

                var laserColliders = Physics.OverlapCapsule(_muzzleTransform.position, targetPoint,
                    _weaponConfiguration_ScriptableObject.BeamSize, _layerMask);
                
                if (laserColliders.Length > 0)
                {
                    targetPoint = laserColliders[0].transform.position;
                    foreach (var collision in laserColliders)
                    {
                        // Listen for a collision hit and apply damage if possible
                        var damagable = collision.GetComponentInParent<IDamagable>();
                        if (damagable != null)
                        {
                            var damage = _weaponConfiguration_ScriptableObject.Damage * -1;

                            damagable.Damage(StatType.Health, damage);
                        }
                    }
                }
                
                _lineRenderer.SetPosition(1, targetPoint);
            }
        }
    }
}