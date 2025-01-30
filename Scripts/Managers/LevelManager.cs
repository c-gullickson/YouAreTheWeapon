using System;
using Constants;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class LevelManager: MonoBehaviour
    {
        public event Action OnTutorialCompleted;
        public event EventHandler<LevelCountChangeEvent> OnLevelCompleted;
        public event EventHandler<LevelTimeRemainingEvent> OnLevelTimeRemaining;

        public static LevelManager Instance { get; private set; }
        private static LevelManager _instance;        
        private void Awake()
        {
            // Check if another instance exists
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning("Another instance of Level Manager Instance already exists! Destroying this one.");
                Destroy(gameObject); // Prevent duplicate managers
                return;
            }
            
            // Set the instance to this object
            Instance = this;
            
            DontDestroyOnLoad(this.gameObject);
        }

        /// <summary>
        /// When starting a new level, pass an action to the UI
        /// </summary>
        /// <param name="level"></param>
        public void NewLevel(int level)
        {
            OnLevelCompleted?.Invoke(this, new LevelCountChangeEvent(){levelCount = level + 1});
        }

        public void LevelWaitRemaining(float time)
        {
            OnLevelTimeRemaining?.Invoke(this, new LevelTimeRemainingEvent() {levelTime = time});
        }
        

        /// <summary>
        /// Load a new scene additively to the scene that is existing
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadTutorialScene(string sceneName)
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                // Check if the scene is already loaded
                if (!SceneManager.GetSceneByName(sceneName).isLoaded)
                {
                    // Load the scene additively
                    SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                }
            }
            else
            {
                Debug.LogWarning("SceneData is not set or the scene name is empty!");
            }
        }
        
        /// Unload an existing scene
        public void UnloadTutorialScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
            OnTutorialCompleted?.Invoke();
        }

        
        /// <summary>
        /// The game has ended so load in game over scene
        /// </summary>
        /// <param name="isWin"></param>
        public void GameOver(bool isWin)
        {
            string sceneToLoad = isWin ? "GameOverWinScene" : "GameOverLoseScene"; 
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}