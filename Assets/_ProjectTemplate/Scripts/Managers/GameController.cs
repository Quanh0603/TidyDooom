using _ProjectTemplate.Scripts.Base;
using GameTool.Audio.Scripts;
using GameToolSample.Audio;
using GameToolSample.GameDataScripts.Scripts;
using GameToolSample.GamePlay.Manager;
using UnityEngine;

namespace _ProjectTemplate.Scripts.Managers
{
    public class GameController : GameManager
    {
        public new static GameController Instance => (GameController)GameManager.Instance;

        private LevelBase loadedLevel;

        protected override void Start()
        {
            base.Start();
            
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic(eMusicName.BG_Ingame);

            var level = GameData.Instance.GameModeData.Level;
            LoadLevel(level);
        }

        public void LoadLevel(LevelBase level)
        {
            if (loadedLevel)
            {
                loadedLevel.DestroyLevel();
                Destroy(loadedLevel.gameObject);
            }

            loadedLevel = Instantiate(level, transform);
            Debug.Log("Loading Level");
        }

        public void LoadLevel(int levelIndex)
        {
            if (loadedLevel)
            {
                loadedLevel.DestroyLevel();
                Destroy(loadedLevel.gameObject);
            }

            var level = Resources.Load<LevelBase>($"_Levels/Level_{levelIndex}");
            loadedLevel = Instantiate(level, transform);
            Debug.Log("Loading Level: " + level.name);
        }

        public void PauseGame()
        {
            if (loadedLevel != null)
            {
                loadedLevel.Pause();
            }
        }

        public void ResumeGame()
        {
            if (loadedLevel != null)
            {
                loadedLevel.Resume();
            }
        }
    }
}