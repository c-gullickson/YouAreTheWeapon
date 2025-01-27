using UnityEngine;
using UnityEngine.SceneManagement;

namespace UserInterface.GameOver
{
    public class GameOver: MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Game Over");
        }

        public void OnMainMenu_ButtonClick()
        {
            Debug.Log("OnMainMenu_ButtonClick");
            SceneManager.LoadScene("MainMenuScene");
        }
        
    }
}