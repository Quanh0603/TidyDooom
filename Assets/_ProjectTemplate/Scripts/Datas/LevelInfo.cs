using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace _ProjectTemplate.Scripts.Datas
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "_Game Data/LevelInfo", order = 0)]
    public class LevelInfo : ScriptableObject
    {
        public int level;

        public Sprite spriteInHome;

        public int timePlay;

        public List<Sprite> hintSprites;

        public int levelParse => int.Parse(name.Replace("Level ", ""));

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (level == 0)
            {
                level = int.Parse(name.Replace("Level ", ""));
            }

            timePlay = 60;
            EditorUtility.SetDirty(this);
        }
#endif
    }
}