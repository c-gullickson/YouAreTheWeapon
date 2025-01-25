using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Stat Configuration ScriptableObject", menuName = "ScriptableObject/StatConfiguration")]
    public class StatConfiguration_ScriptableObject: ScriptableObject
    {
        public List<Stat_ScriptableObject> AppliedStatsList = new List<Stat_ScriptableObject>();
    }
}