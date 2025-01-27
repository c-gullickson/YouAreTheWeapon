using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Scriptable Object", menuName = "ScriptableObject/LevelConfiguration")]
    public class LevelConfiguration_ScriptableObject: ScriptableObject
    {
        public List<Level_ScriptableObject> Levels = new List<Level_ScriptableObject>();
    }
}