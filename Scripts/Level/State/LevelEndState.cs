using Level.Controller;
using UnityEngine;

namespace Level.State
{
    public class LevelEndState: LevelBaseState
    {
        public LevelEndState(LevelController levelController) : base(levelController)
        {
            
        }

        public override void Enter()
        {
            Debug.Log("Enter Level End State");
            if (_levelController.CurrentLevelScriptableObject.LevelEndEvents.Count == 0)
            {
                _levelController.IncreaseLevel();
            }
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            Debug.Log("Exit Level End State");
        }
    }
}