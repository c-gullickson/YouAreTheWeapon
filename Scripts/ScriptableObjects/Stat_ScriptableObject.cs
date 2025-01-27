using Constants;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Stat ScriptableObject", menuName = "ScriptableObject/Stat")]
    public class Stat_ScriptableObject: ScriptableObject
    {
        [Header("Stat Details")]
        public StatType statType;
        public string StatName;
        public string StatDescription;
        public Color StatColor;
        
        [Header("Stat Values")]
        public float StatStartValue;
    }
}