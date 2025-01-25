using System;

namespace Constants
{

    public class StatChangeEvent : EventArgs
    {
        public StatType statType;
        public float statCurrentValue;
        public float statMaxValue;
    }
}