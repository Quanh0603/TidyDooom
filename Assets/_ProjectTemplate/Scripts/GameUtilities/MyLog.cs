using UnityEngine;

namespace _ProjectTemplate.Scripts.GameUtilities
{
    public static class MyLog
    {
        public static bool EnableLog
        {
            get => Debug.developerConsoleEnabled;
            set => Debug.developerConsoleEnabled = value;
        }
    }
}