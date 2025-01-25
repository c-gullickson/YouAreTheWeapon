using UnityEngine;
using UnityEngine.SceneManagement;

namespace UserInterface.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// Transition the scene into the main world scene
        /// </summary>
        public void OnPlay_ButtonClick()
        {
            Debug.Log("OnPlay_ButtonClick");
            SceneManager.LoadScene("WorldScene");
        }

        
        /// <summary>
        /// Transition the scene into the Option Scene
        /// </summary>
        public void OnOptions_ButtonClick()
        {
            Debug.Log("OnOptions_ButtonClick");
            SceneManager.LoadScene("OptionsScene");
        }
        
        
        /// <summary>
        /// Exit the application
        /// </summary>
        public void OnQuit_ButtonClick()
        {
            Debug.Log("OnQuit_ButtonClick");
            Application.Quit();
        }
    }
}