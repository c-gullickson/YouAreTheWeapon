using System;
using System.Collections.Generic;
using BaseComponents;
using Constants;
using UnityEngine;
using UserInterface.Common;

namespace UserInterface.PlayerHud
{
    public class PlayerStats_UserInterface : MonoBehaviour
    {
        [SerializeField] private GameObject _fillbarPrefab;
        
        private Dictionary<StatType, Fillbar_UserInterface> _fillbars = new Dictionary<StatType, Fillbar_UserInterface>();

        public void AddPlayerStat(IStat stat)
        {
            stat.OnStatChange += Stat_OnStatChangeEvent;
            Debug.Log($"New Stat: {stat}");
            
            var fillbar = Instantiate(_fillbarPrefab, transform).GetComponent<Fillbar_UserInterface>();
            fillbar.SetFillColor(stat.GetStatColor());
            _fillbars.Add(stat.GetStatType(), fillbar);
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
            
            // Calculate the amount of the fillbar
            var fillbarToModify = _fillbars[e.statType];
            fillbarToModify.Fill(e.statCurrentValue, e.statMaxValue);
        }
    }
}