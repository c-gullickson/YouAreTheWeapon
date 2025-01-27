using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Scriptable Object", menuName = "ScriptableObject/Level")]
    public class Level_ScriptableObject: ScriptableObject
    {
        [Header("Level Details")]
        public int Level;
        
        [Header("Level Tutorial")]
        public string LevelTutorialName;
        
        [Header("Level Enemies")]
        public List<EnemySpawn_ScriptableObject> Enemies = new List<EnemySpawn_ScriptableObject>();

        [Header("Level Events")] 
        public List<LevelEvent_ScriptableObject> LevelStartEvents = new List<LevelEvent_ScriptableObject>();
        public List<LevelEvent_ScriptableObject> LevelEndEvents = new List<LevelEvent_ScriptableObject>();
    }
}