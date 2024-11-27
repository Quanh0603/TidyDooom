using GameTool.Audio.Scripts;
using GameToolSample.GameDataScripts.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace _ProjectTemplate.Scripts.UI
{
    public class UISettingElement : MonoBehaviour
    {
        public Button on;
        public Button off;

        public Slider slider;

        public bool isMusic;

        private void Start()
        {
            if (slider)
            {
                slider.onValueChanged.AddListener(OnValueChangedEvent);
            }

            if (on && off)
            {
                on.onClick.AddListener(SwitchVibration);
                off.onClick.AddListener(SwitchVibration);
            }
        }

        private void SwitchVibration()
        {
            GameData.Instance.Vibrate = !GameData.Instance.Vibrate;
            UpdateStatus();
        }

        private void OnEnable()
        {
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            if (on && off)
            {
                var value = GameData.Instance.Vibrate;
                on.gameObject.SetActive(value);
                off.gameObject.SetActive(!value);
            }

            if (slider)
            {
                slider.value = isMusic ? GameData.Instance.MusicVolume : GameData.Instance.SoundFXVolume;
            }
        }

        private void OnValueChangedEvent(float arg0)
        {
            if (isMusic)
            {
                AudioManager.Instance.SetMusicVolume(arg0);
            }
            else
            {
                AudioManager.Instance.SetSFXVolume(arg0);
            }
        }
    }
}