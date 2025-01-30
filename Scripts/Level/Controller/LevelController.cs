using System.Collections.Generic;
using Level.State;
using Managers;
using Models.Interfaces;
using ScriptableObjects;
using Spawns.Controller;
using UnityEngine;

namespace Level.Controller
{
    public class LevelController: MonoBehaviour
    {
        [SerializeField] private LevelConfiguration_ScriptableObject _levelConfigurationScriptableObject;
        
        private LevelBaseState _currentState;
        private int _currentLevelIndex = 0;
        public int CurrentLevelIndex => _currentLevelIndex;
        
        
        private Level_ScriptableObject _currentLevelScriptableObject;
        public Level_ScriptableObject CurrentLevelScriptableObject => _currentLevelScriptableObject;

        
        // Known List of Spawns
        private List<ISpawnable> _basicSpawnControllers = new List<ISpawnable>();
        private List<Transform> _basicSpawnControllerTransforms = new List<Transform>();
        public List<Transform> BasicSpawnControllerTransforms => _basicSpawnControllerTransforms;

        private List<ISpawnable> _advancedSpawnControllers = new List<ISpawnable>();
        private List<Transform> _advancedSpawnControllerTransforms = new List<Transform>();
        public List<Transform> AdvancedSpawnControllerTransforms => _advancedSpawnControllerTransforms;


        private void Awake()
        {
            // Set to the first level
            LevelManager.Instance.NewLevel(_currentLevelIndex);
            
            _currentLevelScriptableObject = _levelConfigurationScriptableObject.Levels[_currentLevelIndex];
            _currentState = new LevelTutorialState(this);
            _currentState.Enter();
            
            // Add basic spawns and spawn transforms
            _basicSpawnControllers.AddRange(GetComponentsInChildren<BasicSpawnController>(true));
            foreach (BasicSpawnController basicSpawnController in _basicSpawnControllers)
            {
                _basicSpawnControllerTransforms.Add(basicSpawnController.transform);;
            }
            
            // Add advanced spawns and spawn transforms
            _advancedSpawnControllers.AddRange(GetComponentsInChildren<AdvancedSpawnController>(true));
            foreach (AdvancedSpawnController advancedSpawnController in _advancedSpawnControllers)
            {
                _advancedSpawnControllerTransforms.Add(advancedSpawnController.transform);;
            }
        }
        
        private void Update()
        {
            _currentState?.Update();
        }
        
        /// <summary>
        /// Transition from one state to the next
        /// </summary>
        /// <param name="newState"></param>
        public void TransitionToState(LevelBaseState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        /// <summary>
        /// Increase current level count and set the current level scriptable object to what is the next level 
        /// </summary>
        public void IncreaseLevel()
        {
            _currentLevelIndex++;
            
            // Ensure that there are still levels to load
            // Otherwise, provide the player a game over scene
            if (_currentLevelIndex < _levelConfigurationScriptableObject.Levels.Count)
            {
                _currentLevelScriptableObject = _levelConfigurationScriptableObject.Levels[_currentLevelIndex];
                LevelManager.Instance.NewLevel(_currentLevelIndex);

                TransitionToState(new LevelTutorialState(this));
            }
            else
            {
                LevelManager.Instance.GameOver(true);
            }
        }
    }
}