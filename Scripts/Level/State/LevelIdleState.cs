using Level.Controller;
using Managers;
using UnityEngine;

namespace Level.State
{
    public class LevelIdleState: LevelBaseState
    {
        private float _timeBeforeStart = 5f;
        private bool _isStart = false;
        
        public LevelIdleState(LevelController levelController) : base(levelController)
        {
            
        }
        
        public override void Enter()
        {
            Debug.Log($"Enter Level Idle State {_levelController.CurrentLevelIndex}");
            _isStart = true;
        }

        public override void Update()
        {
            if (_isStart)
            {
                // Countdown the timer before transitioning to the Level Play State
                if (_timeBeforeStart > 0)
                {
                    _timeBeforeStart -= Time.deltaTime;
                    LevelManager.Instance.LevelWaitRemaining(_timeBeforeStart);
                    
                    Debug.Log($"Round PreStart Timer... Time left: {_timeBeforeStart:F2} seconds");
                }
                else
                {
                    _levelController.TransitionToState(new LevelPlayState(_levelController));
                }
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Level Idle State");
        }
    }
}