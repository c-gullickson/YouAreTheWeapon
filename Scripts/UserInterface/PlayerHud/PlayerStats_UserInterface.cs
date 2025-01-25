using System;
using BaseComponents;
using Constants;
using UnityEngine;

namespace UserInterface.PlayerHud
{
    public class PlayerStats_UserInterface : MonoBehaviour
    {
        /// <summary>
        /// Get all UI Components
        /// </summary>
        private void Awake()
        {
            
        }

        public void AddPlayerStat(IStat stat)
        {
            stat.OnStatChange += Stat_OnStatChangeEvent;
            Debug.Log($"New Stat: {stat}");
        }

        /// <summary>
        /// Listen for a stat to have changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stat_OnStatChangeEvent(object sender, StatChangeEvent e)
        {
            Debug.Log($"PlayerStats_UserInterface::Stat_OnStatChangeEvent {e}");
            Debug.Log($"StatType: {e.statType} StatAmount: {e.statCurrentValue} StatMax: {e.statMaxValue}");
        }
    }
}