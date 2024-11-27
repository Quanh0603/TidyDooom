using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _ProjectTemplate.Scripts.Datas
{
    [CreateAssetMenu(fileName = "LevelDataResources", menuName = "_Game Data/LevelDataResources", order = 0)]
    public class LevelDataResources : ScriptableObject
    {
        public List<LevelInfo> levels = new List<LevelInfo>();

        public LevelInfo GetLevelInfo(int level)
        {
            return levels.FirstOrDefault(info => info.level == level);
        }
    }


}