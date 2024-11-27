using System;
using _ProjectTemplate.Scripts.Base;
using _ProjectTemplate.Scripts.Datas;
using _ProjectTemplate.Scripts.UI;
using GameTool.Audio.Scripts;
using GameToolSample.Audio;
using GameToolSample.GameDataScripts.Scripts;
using GameToolSample.GamePlay.Manager;
using GameToolSample.Scripts.Enum;
using UnityEngine;

namespace _ProjectTemplate.Scripts.Managers
{
    public class GameController : GameManager
    {
        public new static GameController Instance => (GameController)GameManager.Instance;

        private LevelBase loadedLevel;
        private LevelInfo levelInfo;

        private float totalTime;
        private float timeLeft;

        public float TimeLeft => timeLeft;

        protected void Start()
        {
            PlayGame();
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
            levelInfo = DataResources.GetLevelDataResources().GetLevelInfo(levelIndex);
            loadedLevel = Instantiate(level, transform);
            totalTime = levelInfo.timePlay;
            timeLeft = totalTime;
            GameplayMenu.Instance.UpdateTimer(timeLeft);
            bool activeHint = levelInfo.hintSprites.Count > 0;
            GameplayMenu.Instance.hintButton.gameObject.SetActive(activeHint);
        }

        public void PauseGame()
        {
            GameplayStatus = AnalyticID.GamePlayState.pause;
            if (loadedLevel != null)
            {
                loadedLevel.Pause();
            }
        }

        public void ResumeGame()
        {
            GameplayStatus = AnalyticID.GamePlayState.playing;
            if (loadedLevel != null)
            {
                loadedLevel.Resume();
            }
        }

        private void Update()
        {
            if (!IsGamePlayStatus(AnalyticID.GamePlayState.playing))
            {
                return;
            }

            timeLeft -= Time.deltaTime;
            GameplayMenu.Instance.UpdateTimer(timeLeft);
        }

        public override void SkipLevel()
        {
            Debug.LogError("Game Controller: ---- Skip Level");
        }

        public override void ReplayLevel()
        {
            Debug.LogError("Game Controller: ---- Replay Level");
        }
    }
}