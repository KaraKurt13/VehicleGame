using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "LevelData")]
    public class LevelData : ScriptableObject
    {
        public int Length;

        public int EnemiesPerTile;
    }
}