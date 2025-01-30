using System;
using Constants;
using Managers;
using TMPro;
using UnityEngine;

namespace UserInterface.PlayerHud
{
    public class LevelStats_UserInterface: MonoBehaviour
    {
        private TextMeshProUGUI _levelText;
        private TextMeshProUGUI _enemyCountText;
        
        private string _enemyCountText_text = "Enemies ";
        private string _levelText_text = "Level ";

        
        private void Awake()
        {
           
            _levelText = GameObject.Find("Round_Text").GetComponent<TextMeshProUGUI>();
            _enemyCountText = GameObject.Find("EnemyCount_Text").GetComponent<TextMeshProUGUI>();
            
            EnemyManager.Instance.OnEnemyCountChange += EnemyManager_OnEnemyCountChange;
            LevelManager.Instance.OnLevelCompleted += LevelManager_OnLevelCompleted;
            
            _enemyCountText.text = "0";
            _levelText.text = "0";
        }
       
        
        /// <summary>
        /// Listen for the event where the number of enemies changes, update the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnemyManager_OnEnemyCountChange(object sender, EnemyCountChangeEvent e)
        {
            var text = $"{_enemyCountText_text} {e.enemyCount}";
            _enemyCountText.text = text;
        }

        /// <summary>
        /// Listen for the event where the level number changes, update the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelManager_OnLevelCompleted(object sender, LevelCountChangeEvent e)
        {
            var text = $"{_levelText_text} {e.levelCount}";
            _levelText.text = text;
        }
    }
}