using System;
using System.Collections.Generic;
using Constants;
using ScriptableObjects;

namespace Models.Interfaces
{
    public interface IStatistics
    {
        public void Initialize(StatConfiguration_ScriptableObject statConfiguration);
        public void AddNewStat(Stat_ScriptableObject stat);
        public void RemoveStat(StatType statType);
        public void ModifyStat(Dictionary<StatType,float> modifiedStats);
        

        public Action<StatType> OnStatZero { get; set; }
    }
}