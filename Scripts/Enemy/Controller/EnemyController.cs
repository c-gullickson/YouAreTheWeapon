using System;
using System.Collections.Generic;
using BaseComponents;
using Constants;
using Enemy.Component;
using Enemy.State;
using Models.Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Enemy.Controller
{
    public class EnemyController: MonoBehaviour, IDamagable
    {
        /// TODO: Change this to be a derived value?
        [SerializeField] public Vector3 _targetPosition;
        [SerializeField] private StatConfiguration_ScriptableObject _statConfiguration_ScriptableObject;

        
        private EnemyState _currentState;
        private IStatistics _enemyStats = null;
        
        internal Vector3 _spawningPosition;
        
        private void Awake()
        {
            _spawningPosition = transform.position;
            _currentState = new EnemyIdleState(this);
            _currentState.Enter();

            _enemyStats = new EnemyStats();
            _enemyStats.Initialize(_statConfiguration_ScriptableObject);
            _enemyStats.OnStatZero += Statistics_OnStatZero;
        }

        private void Update()
        {
            _currentState.Update();
        }
        
        /// <summary>
        /// Transition from one state to the next
        /// </summary>
        /// <param name="newState"></param>
        public void TransitionToState(EnemyState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        /// <summary>
        /// Take damage from a damage source
        /// </summary>
        /// TODO: need to pass across a damage type? 
        public void Damage()
        {
            Debug.Log("Damange Enemy Controller");
            Dictionary<StatType, float> _stats = new Dictionary<StatType, float>();
            _stats.Add(StatType.Health, -10);
            
            _enemyStats.ModifyStat(_stats);
        }
        
        /// <summary>
        /// Listen for when certain stats hit zero
        /// </summary>
        /// <param name="statType"></param>
        private void Statistics_OnStatZero(StatType statType)
        {
            switch (statType)
            {
                case StatType.Health:
                    Destroy(this.gameObject);
                    break;
                case StatType.Armor:
                    break;
                case StatType.Shield:
                    break;
                default:
                    Debug.LogError($"Unknown stat type: {statType}");
                    break;
            }
        }
    }
}