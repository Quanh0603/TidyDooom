using _ProjectTemplate.Scripts.Datas;
using GameTool.Audio.Scripts;
using GameToolSample.Audio;
using GameToolSample.GameDataScripts.Scripts;
using GameToolSample.Scripts.LoadScene;
using UnityEngine;
using UnityEngine.UI;

namespace _ProjectTemplate.Scripts.UI
{
    public class LevelElementHome : MonoBehaviour
    {
        public Image imageCenter;
        public Image imageLock;
        public Text text;
        public Button button;

        private LevelInfo _levelInfo;

        private bool _isUnlocked;

        public void SetData(LevelInfo info)
        {
            _levelInfo = info;
            imageCenter.sprite = _levelInfo.spriteInHome;
            imageLock.sprite = _levelInfo.spriteInHome;
            text.text = $"Level {_levelInfo.level}";

            _isUnlocked = GameData.Instance.CheckLevelUnlock(_levelInfo.level);
            imageLock.gameObject.SetActive(!_isUnlocked);
            
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            AudioManager.Instance.Shot(eSoundName.ButtonClick);

            if (_isUnlocked)
            {
                GameData.Instance.GameModeData.Level = _levelInfo.level;

                SceneLoadManager.Instance.LoadSceneGamePlay();
            }
        }
    }
}