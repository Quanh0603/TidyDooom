using UnityEngine;

namespace _ProjectTemplate.Scripts.GameUtilities
{
    public static class PlayerPrefsUtilities
    {
        public static bool Music
        {
            get => PlayerPrefs.GetInt("Music", 1) == 1;
            set => PlayerPrefs.SetInt("Music", value ? 1 : 0);
        }
        
        public static bool SoundFX
        {
            get => PlayerPrefs.GetInt("SoundFX", 1) == 1;
            set => PlayerPrefs.SetInt("SoundFX", value ? 1 : 0);
        }
        
        public static bool Vibrate
        {
            get => PlayerPrefs.GetInt("Vibrate", 1) == 1;
            set => PlayerPrefs.SetInt("Vibrate", value ? 1 : 0);
        }
        
        public static float MusicVolume
        {
            get => PlayerPrefs.GetFloat("MusicVolume", 1f);
            set
            {
                var val = Mathf.Clamp(value, 0f, 1f);
                PlayerPrefs.SetFloat("MusicVolume", val);
            }
        }
        
        public static float SoundVolume
        {
            get => PlayerPrefs.GetFloat("SoundVolume", 1f);
            set
            {
                var val = Mathf.Clamp(value, 0f, 1f);
                PlayerPrefs.SetFloat("SoundVolume", val);
            }
        }
    }
}