using _ProjectTemplate.Scripts.Datas;
using UnityEngine;

namespace _ProjectTemplate.Scripts
{
    public static class DataResources
    {

        public static LevelDataResources GetLevelDataResources()
        {
            return Resources.Load<LevelDataResources>($"Datas/LevelDataResources");
        }
    }
}