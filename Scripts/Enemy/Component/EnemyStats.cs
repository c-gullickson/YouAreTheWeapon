using System;
using System.Collections.Generic;
using BaseComponents;
using Constants;
using Models.Interfaces;
using ScriptableObjects;

namespace Enemy.Component
{
    public class EnemyStats : IStatistics
    {
        public Action<StatType> OnStatZero { get; set; }

        private Dictionary<StatType, IStat> _enemyStats;

        // Construct a new PlayerStats object
        public EnemyStats()
        {
            _enemyStats = new Dictionary<StatType, IStat>();
        }

        /// <summary>
        /// Pass a configured list of stat scriptable objects to be initilaized as stat objects
        /// Create a connection between all of the stats and the Player UI
        /// </summary>
        /// <param name="statConfiguration"></param>
        public void Initialize(StatConfiguration_ScriptableObject statConfiguration)
        {
            // Create a dictionary containing each new stat
            foreach (var newStat in statConfiguration.AppliedStatsList)
            {
                var statToAdd = new Stat(newStat.statType, newStat.StatStartValue);
                _enemyStats.Add(newStat.statType, statToAdd);
            }
        }

        /// <summary>
        /// Add a new stat to the dictionary
        /// </summary>
        /// <param name="stat"></param>
        public void AddNewStat(Stat_ScriptableObject stat)
        {
            _enemyStats.TryAdd(stat.statType, new Stat(stat.statType, stat.StatStartValue));
        }

        /// <summary>
        /// Remove a stat from the dictionary
        /// </summary>
        /// <param name="statType"></param>
        public void RemoveStat(StatType statType)
        {
            _enemyStats.Remove(statType);
        }

        /// <summary>
        /// For each stat passed (As multiple stats could be impacted by an action) increase or decrease each one
        /// </summary>
        /// <param name="modifiedStats"></param>
        public void ModifyStat(Dictionary<StatType,float> modifiedStats)
        {
            float statModifiedAmount = 0;
            foreach (var modifiedStat in modifiedStats)
            {
                var targetStat = _enemyStats[modifiedStat.Key];

                // If the modified stat value is less than zero, assume a decrease
                // Otherwise, assume an increase
                if (modifiedStat.Value < 0)
                {
                    statModifiedAmount = targetStat.DecreaseStat(modifiedStat.Value);
                    if (statModifiedAmount == 0)
                    {
                        OnStatZero(modifiedStat.Key);
                    }
                }
                else
                {
                    statModifiedAmount = targetStat.IncreaseStat(modifiedStat.Value);
                }
            }
        }

    }
}