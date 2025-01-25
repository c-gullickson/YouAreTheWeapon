using System;
using Constants;
using UnityEngine;

namespace BaseComponents
{
    public interface IStat
    {
        public float IncreaseStat(float amount);
        public float DecreaseStat(float amount);

        public event EventHandler<StatChangeEvent> OnStatChange;
    }

    public class Stat : IStat
    {
        private StatType _statType;
        private float _currentStatAmount;
        private float _maxStatAmount;

        public event EventHandler<StatChangeEvent> OnStatChange;

        public Stat(StatType statType, float maxStatAmount)
        {
            _statType = statType;
            _currentStatAmount = maxStatAmount;
            _maxStatAmount = maxStatAmount;
        }

        /// <summary>
        /// Increase the stat's current amount and trigger an event
        /// </summary>
        /// <param name="amount"></param>
        public float IncreaseStat(float amount)
        {
            _currentStatAmount += amount;
            _currentStatAmount = Mathf.Clamp(_currentStatAmount, 0, _maxStatAmount);
            OnStatChange?.Invoke(this,
                new StatChangeEvent()
                    { statType = _statType, statCurrentValue = _currentStatAmount, statMaxValue = _maxStatAmount });
            
            return _currentStatAmount;
        }

        /// <summary>
        /// Decrease the stats current amount and trigger an event
        /// </summary>
        /// <param name="amount"></param>
        public float DecreaseStat(float amount)
        {
            _currentStatAmount += amount;
            _currentStatAmount = Mathf.Clamp(_currentStatAmount, 0, _maxStatAmount);
            OnStatChange?.Invoke(this,
                new StatChangeEvent()
                    { statType = _statType, statCurrentValue = _currentStatAmount, statMaxValue = _maxStatAmount });
            
            return _currentStatAmount;
        }
    }
}