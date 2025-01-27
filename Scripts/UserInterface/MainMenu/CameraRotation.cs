using System;
using UnityEngine;

namespace UserInterface.MainMenu
{
    public class CameraRotation: MonoBehaviour
    {
        [SerializeField] private Transform _rotationAroundTarget; // The object to rotate around
        private float _cameraRotationSpeed = 20f;
        
        private void Update()
        {
            if (_rotationAroundTarget != null)
            {
                // Rotate the camera around the target
                transform.RotateAround(_rotationAroundTarget.position, Vector3.up, _cameraRotationSpeed * Time.deltaTime);
                transform.LookAt(_rotationAroundTarget); // Keep the camera looking at the target
            }
        }
    }
}