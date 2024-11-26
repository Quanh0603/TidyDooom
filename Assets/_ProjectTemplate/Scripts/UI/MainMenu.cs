using _ProjectTemplate.Scripts.Datas;
using GameTool.Audio.Scripts;
using GameTool.UI.Scripts.CanvasPopup;
using GameToolSample.Audio;
using UnityEngine;

namespace _ProjectTemplate.Scripts.UI
{
    public class MainMenu : SingletonUI<MainMenu>
    {
        [Header("Data")] public LevelDataResources levelDataResources;

        [Header("References")] public Transform content;

        public LevelElementHome levelElementHomePrefab;

        protected override void Awake()
        {
            base.Awake();

            if (!levelDataResources)
            {
                levelDataResources = DataResources.GetLevelDataResources();
            }
        }

        private void Start()
        {
            AudioManager.Instance.PlayMusic(eMusicName.BG_Home);
            SpawnScrollView();
        }

        private void SpawnScrollView()
        {
            for (int i = 0; i < levelDataResources.levels.Count; i++)
            {
                var level = levelDataResources.levels[i];
                var levelElement = Instantiate(levelElementHomePrefab, content);
                levelElement.SetData(level);
            }
        }
    }
}