using Constants;
using Managers;
using TMPro;
using UnityEngine;

namespace UserInterface.PlayerHud
{
    public class TimerStats_UserInterface: MonoBehaviour
    {
        private TextMeshProUGUI _timerText;
        
        private string _roundTimeCountText_text = "Round Start: \n ";

        
        private void Awake()
        {
            _timerText = GameObject.Find("Timer_Text").GetComponent<TextMeshProUGUI>();
            
            LevelManager.Instance.OnLevelTimeRemaining += LevelManager_OnLevelTimeRemaining;
            
            _timerText.text = "0";
        }
       
        
        /// <summary>
        /// Listen for the event where the number of enemies changes, update the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelManager_OnLevelTimeRemaining(object sender, LevelTimeRemainingEvent e)
        {
            var text = $"{_roundTimeCountText_text} \n {e.levelTime:F2} seconds";
            _timerText.text = text;
        }
    }
}