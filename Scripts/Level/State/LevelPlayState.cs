using System;
using System.Collections.Generic;
using Level.Controller;
using Managers;
using Models.Interfaces;
using ScriptableObjects;
using UnityEngine;
using Random = System.Random;

namespace Level.State
{
    public class LevelPlayState : LevelBaseState
    {
        private Random random = new Random();

        private bool _hasEnemiesToSpawn = true;
        private bool _hasEnemiesRemaining = false;

        private Queue<EnemySpawn_ScriptableObject> _spawnableEnemies = new Queue<EnemySpawn_ScriptableObject>();
        private EnemySpawn_ScriptableObject _currentEnemiesSpawning;

        private int _enemiesToSpawn = 0;
        private float _spawnDelayTimer = 0f;
        private List<Transform> _spawnControllerTransforms = new List<Transform>();
        
        public LevelPlayState(LevelController levelController) : base(levelController)
        {
            // Add each enemy spawn type into a queue
            foreach (var enemy in _levelController.CurrentLevelScriptableObject.Enemies)
            {
                if (_spawnableEnemies != null) _spawnableEnemies.Enqueue(enemy);
            }
        }

        public override void Enter()
        {
            EnemyManager.Instance.OnAllEnemiesDestroyed += EnemyManager_OnAllEnemiesDestroyed;
            Debug.Log("Enter Level Play State");
            _currentEnemiesSpawning = _spawnableEnemies.Dequeue();
            _enemiesToSpawn = _currentEnemiesSpawning.NumberOfEnemiesToSpawn;
            _spawnDelayTimer = _currentEnemiesSpawning.SpawnDelay;

            _hasEnemiesToSpawn = true;
            _hasEnemiesRemaining = true;
        }

        public override void Update()
        {
            if (_currentEnemiesSpawning == null)
            {
                Debug.Log("Empty Current Enemy Spawn");
                // If nothing is left to spawn, and all enemies on screen have been defeated, then transition to the end state of the level
                if (!_hasEnemiesRemaining)
                {
                    _levelController.TransitionToState(new LevelEndState(_levelController));
                }
            }


            // Countdown the timer before transitioning to the Level Play State
            if (_spawnDelayTimer <= 0)
            {
                // Still have enemies to try and spawn
                if (_enemiesToSpawn > 0)
                {
                    var _spawnControllerTransforms = _levelController.BasicSpawnControllerTransforms;
                    var spawn = GetRandomSpawnObject(_spawnControllerTransforms);
                    
                    // Spawn a new enemy
                    EnemyManager.Instance.InstantiateAndAddEnemyToList(_currentEnemiesSpawning.EnemyPrefab, spawn);
                    _spawnDelayTimer = _currentEnemiesSpawning.SpawnDelay;
                    _enemiesToSpawn--;
                }
                else
                {
                    _spawnableEnemies.TryDequeue(out _currentEnemiesSpawning);
                }
            }
            
            _spawnDelayTimer -= Time.deltaTime;
        }

        public override void Exit()
        {
            Debug.Log("Exit Level Play State");
        }
        
        public T GetRandomSpawnObject<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
                throw new InvalidOperationException("The list is empty or null.");

            int randomIndex = random.Next(0, list.Count);

            return list[randomIndex];
        }
        
        private void EnemyManager_OnAllEnemiesDestroyed()
        {
            _hasEnemiesRemaining = false;
        }
    }
}