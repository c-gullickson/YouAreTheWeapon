using Level.Controller;
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

        /// <summary>
        /// TODO: Should instantiate the player UI for upgrades
        /// TODO: When complete, start the countdown for round starting
        /// </summary>
        public override void Enter()
        {
            Debug.Log("EnterLevel Idle State");
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