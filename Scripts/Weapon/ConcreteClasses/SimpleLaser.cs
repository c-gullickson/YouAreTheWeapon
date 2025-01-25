using Models.Interfaces;
using ScriptableObjects;
using UnityEngine;
using Weapon.Controller;

namespace Weapon.ConcreteClasses
{
    public class SimpleLaser : WeaponController
    {
        private WeaponConfiguration_ScriptableObject _weaponConfiguration_ScriptableObject;
        private LineRenderer _lineRenderer;
        private Transform _muzzleTransform;
        
        private LayerMask _layerMask;
        
        public SimpleLaser(WeaponConfiguration_ScriptableObject weaponConfiguration_ScriptableObject)
        {
            _weaponConfiguration_ScriptableObject = weaponConfiguration_ScriptableObject;
            _layerMask = _weaponConfiguration_ScriptableObject.TargetingLayer;
        }


        public override void Initialize(LineRenderer lineRenderer, Transform muzzleTransform)
        {
            _lineRenderer = lineRenderer;
            _muzzleTransform = muzzleTransform;

            _lineRenderer.startColor = _weaponConfiguration_ScriptableObject.BeamColor;
            _lineRenderer.startWidth = .10f;
        }

        public override void ActivateWeapon()
        {
            Debug.Log("Simple Laser Shoot");  

            // Perform a raycast to detect where the laser should hit
            RaycastHit hit;
            Vector3 targetPoint = _muzzleTransform.position + _muzzleTransform.forward * _weaponConfiguration_ScriptableObject.Range;

            if (Physics.Linecast(_muzzleTransform.position, targetPoint, out hit, _layerMask))
            {
                targetPoint = hit.point;
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
            Debug.Log("Simple Laser Shoot");   
        }

        public override void UpdateLaser()
        {
            if (_lineRenderer.enabled)
            {
                // Dynamically update the laser's position
                _lineRenderer.SetPosition(0, _muzzleTransform.position);


                RaycastHit hit;
                Vector3 targetPoint = _muzzleTransform.position + _muzzleTransform.forward * _weaponConfiguration_ScriptableObject.Range;

                if (Physics.Linecast(_muzzleTransform.position, targetPoint, out hit, _layerMask))
                {
                    targetPoint = hit.point;

                    // Listen for a collision hit and apply damage if possible
                    var damagable = hit.collider.GetComponentInParent<IDamagable>();
                    if (damagable != null)
                    {
                        damagable.Damage();
                    }
                }

                _lineRenderer.SetPosition(1, targetPoint);
            }
        }
    }
}