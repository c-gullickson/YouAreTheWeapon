using Constants;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Scriptable Object", menuName = "ScriptableObject/EnemySpawn")]
    public class EnemySpawn_ScriptableObject: ScriptableObject
    {
        [Header("Enemy")]
        public GameObject EnemyPrefab;
        public int NumberOfEnemiesToSpawn;
        
        public EnemySpawnType SpawnType;
        public float SpawnDelay;
    }
}