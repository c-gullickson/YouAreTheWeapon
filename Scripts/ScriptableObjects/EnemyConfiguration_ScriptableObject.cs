using Constants;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Scriptable Object", menuName = "ScriptableObject/EnemyConfiguration")]
    public class EnemyConfiguration_ScriptableObject: ScriptableObject
    {
        [Header("Enemy Details")] 
        public EnemyType EnemyType;
        
        [Header("Movement")]
        public EnemyMovementPattern MovementPattern;
        public float MovementSpeed;
        public float Amplitude;
        public float Frequency;
        
        [Header("Attack")]
        public float AttackRange;

        public float AttackSpeed;
        public float AttackDamage;
        public StatType AttackDamageType;
    }
}