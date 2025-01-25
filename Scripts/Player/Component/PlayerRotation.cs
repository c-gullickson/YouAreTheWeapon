using UnityEngine;

namespace Player.Component
{
    public interface IPlayerRotation
    {
        void RotatePlayer();
        void SetRotationConstants();
    }
    
    public class PlayerRotation : IPlayerRotation
    {
        private GameObject _playerTurret;
        
        // Rotation speed for yaw and pitch adjustments
        private float rotationSpeed = 80f;

        // Clamping rotation limits
        private float minPitch = -45f;
        private float maxPitch = 0f;
        private float minYaw = -90f;
        private float maxYaw = 90f;
        
        private float currentPitch = 0f;
        private float currentYaw = 0f;
        
        
        public PlayerRotation(GameObject turret)
        {
            _playerTurret = turret;
        }
        
        
        /// <summary>
        /// Listen for inputs to update the rotation on the turret mesh
        /// </summary>
        public void RotatePlayer()
        {
            // Get input from Unity's input system (default axis names)
            float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
            float verticalInput = Input.GetAxis("Vertical");     // W/S or Up/Down Arrow

            // Calculate rotation amounts
            float yaw = horizontalInput * rotationSpeed * Time.deltaTime; // Yaw (rotation around Y-axis)
            float pitch = -verticalInput * rotationSpeed * Time.deltaTime; // Pitch (rotation around X-axis, inverted for natural movement)

            // Update current pitch and yaw
            currentPitch = Mathf.Clamp(currentPitch + pitch, minPitch, maxPitch);
            currentYaw = Mathf.Clamp(currentYaw + yaw, minYaw, maxYaw);

            // Apply clamped rotation to the game object
            _playerTurret.transform.localEulerAngles = new Vector3(currentPitch, currentYaw, 0f);
        }

        /// <summary>
        /// Will pass across an object that the player can use to upgrade rotation values
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void SetRotationConstants()
        {
            throw new System.NotImplementedException();
        }
    }
}