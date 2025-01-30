using System;

namespace Constants
{

    public class StatChangeEvent : EventArgs
    {
        public StatType statType;
        public float statCurrentValue;
        public float statMaxValue;
    }

    public class EnemyCountChangeEvent : EventArgs
    {
        public int enemyCount;
    }
    
    public class LevelCountChangeEvent : EventArgs
    {
        public int levelCount;
    }

    public class LevelTimeRemainingEvent : EventArgs
    {
        public float levelTime;
    }
}