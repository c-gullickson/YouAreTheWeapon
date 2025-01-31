using UnityEngine;
using UnityEngine.SceneManagement;

namespace UserInterface.GameOver
{
    public class ReturnToMainMenu: MonoBehaviour
    {
        public void OnMainMenu_ButtonClick()
        {
            Debug.Log("OnMainMenu_ButtonClick");
            SceneManager.LoadScene("MainMenuScene");
        }
        
    }
}