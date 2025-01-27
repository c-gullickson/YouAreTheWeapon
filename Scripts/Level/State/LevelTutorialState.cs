using Level.Controller;
using Managers;
using UnityEngine;

namespace Level.State
{
    public class LevelTutorialState: LevelBaseState
    {
        private bool _isTutorialComplete;

        public LevelTutorialState(LevelController levelController) : base(levelController)
        {
            _isTutorialComplete = false;
        }

        public override void Enter()
        {
            Debug.Log($"Enter Level Tutorial {_levelController.CurrentLevelIndex}");
            
            // If there is no Level Tutorial, transition to the Idle State
            if (string.IsNullOrEmpty(_levelController.CurrentLevelScriptableObject.LevelTutorialName))
            {
                _levelController.TransitionToState(new LevelIdleState(_levelController));
            }
            else
            {
                // Instantiate the Tutorial Scene Game Object
                LevelManager.Instance.LoadTutorialScene(_levelController.CurrentLevelScriptableObject.LevelTutorialName);
                LevelManager.Instance.OnTutorialCompleted += LevelManager_OnTutorialCompleted;
            }
        }

        public override void Update()
        {
            if (_isTutorialComplete)
            {
                _levelController.TransitionToState(new LevelIdleState(_levelController));
            }
        }

        public override void Exit()
        {
            Debug.Log($"Exit Level Tutorial {_levelController.CurrentLevelIndex}");
        }

        /// <summary>
        /// Listen for the tutorial to be completed by the user, then transition to the next state
        /// </summary>
        private void LevelManager_OnTutorialCompleted()
        {
            Debug.Log("Tutorial completed: Changing to Level Idle State");
            LevelManager.Instance.OnTutorialCompleted -= LevelManager_OnTutorialCompleted;
            _isTutorialComplete = true;
        }
    }
}