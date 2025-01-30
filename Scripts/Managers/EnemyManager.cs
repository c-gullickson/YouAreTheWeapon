using System;
using System.Collections.Generic;
using Constants;
using Enemy.Controller;
using UnityEngine;

namespace Managers
{
    public class EnemyManager: MonoBehaviour
    {
        public event Action OnAllEnemiesDestroyed;
        public event EventHandler<EnemyCountChangeEvent> OnEnemyCountChange;

        public static EnemyManager Instance { get; private set; }
        private static EnemyManager _instance;

        private List<EnemyController> _enemies;
        private void Awake()
        {
            _enemies = new List<EnemyController>();
            
            // Check if another instance exists
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning("Another instance of Enemy Manager Instance already exists! Destroying this one.");
                Destroy(gameObject); // Prevent duplicate managers
                return;
            }
            
            // Set the instance to this object
            Instance = this;
            
            DontDestroyOnLoad(this.gameObject);
        }


        /// <summary>
        /// Add enemies to the list
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="spawnLocation"></param>
        public void InstantiateAndAddEnemyToList(GameObject enemy, Transform spawnLocation)
        {
            var newEnemy = Instantiate(enemy, spawnLocation.position, Quaternion.identity);
            _enemies.Add(newEnemy.GetComponent<EnemyController>());
            OnEnemyCountChange?.Invoke(this, new EnemyCountChangeEvent{enemyCount = _enemies.Count});
        }
        
        
        /// <summary>
        /// Remove an enemy from the list
        /// </summary>
        /// <param name="enemy"></param>
        public void RemoveEnemyToList(EnemyController enemy)
        {
            _enemies.Remove(enemy);
            OnEnemyCountChange?.Invoke(this, new EnemyCountChangeEvent{enemyCount = _enemies.Count});

            // If there are no enemies left on the screen, check to see if there are still enemies to spawn
            if (_enemies.Count == 0)
            {
                OnAllEnemiesDestroyed?.Invoke();
            }
        }
    }
}