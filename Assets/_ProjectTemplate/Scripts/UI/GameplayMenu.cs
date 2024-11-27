using System;
using _ProjectTemplate.Scripts.Managers;
using GameTool.Assistants.Helper;
using GameTool.UI.Scripts.CanvasPopup;
using GameToolSample.UIManager;
using TMPro;
using UnityEngine.UI;

namespace _ProjectTemplate.Scripts.UI
{
    public class GameplayMenu : SingletonUI<GameplayMenu>
    {
        public Button pauseButton;
        public Button nextButton;
        public Button hintButton;
        public TextMeshProUGUI txtTimer;

        private void Start()
        {
            pauseButton.onClick.AddListener(GameController.Instance.PauseGame);
            nextButton.onClick.AddListener(NextButtonAction);
            hintButton.onClick.AddListener(HintButtonAction);
        }

        private void NextButtonAction()
        {
            GameController.Instance.SkipLevel();
        }

        private void HintButtonAction()
        {
            CanvasManager.Instance.Push(eUIName.None);
        }

        public void UpdateTimer(float time)
        {
            txtTimer.text = AbbrevationUtility.AbbrevationTimeAuto(time);
        }
    }
}