using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Scriptable Object", menuName = "ScriptableObject/WeaponConfiguration")]
    public class WeaponConfiguration_ScriptableObject: ScriptableObject
    {
        [Header("Weapon Details")]
        public string WeaponName;
        public string WeaponDescription;
        
        [Header("Weapon Values")]
        public float Damage;

        public bool HasCooldown;
        public float CooldownTime;
        
        public float FireDelayTime;
        
        public float Range;
        
        public Color BeamColor;
        public float BeamSize;
        
        public LayerMask TargetingLayer;
    }
}