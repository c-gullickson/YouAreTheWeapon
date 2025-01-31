using Managers;
using UnityEngine;

namespace Level.LevelTutorials
{
    public class LevelTwoTutorialController: MonoBehaviour
    {
        /// <summary>
        /// Transition the scene into the main world scene
        /// </summary>
        public void TutorialComplete_ButtonClick()
        {
            Debug.Log("TutorialComplete_ButtonClick");
            LevelManager.Instance.UnloadTutorialScene("LevelTwoTutorialScene");
        }
    }
}