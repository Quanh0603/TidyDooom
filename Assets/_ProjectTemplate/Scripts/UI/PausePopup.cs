using _ProjectTemplate.Scripts.Managers;
using GameTool.UI.Scripts.CanvasPopup;
using UnityEngine;
using UnityEngine.UI;

namespace _ProjectTemplate.Scripts.UI
{
    public class PausePopup : SingletonUI<PausePopup>
    {
        [SerializeField] private Button closeBtn;
        [SerializeField] private Button retryBtn;
        [SerializeField] private Button skipBtn;

        private void Start()
        {
            closeBtn.onClick.AddListener(CloseAction);
            retryBtn.onClick.AddListener(RetryAction);
            skipBtn.onClick.AddListener(SkipAction);
        }

        private void CloseAction()
        {
            GameController.Instance.ResumeGame();
            Pop();
        }

        private void RetryAction()
        {
            GameController.Instance.ReplayLevel();
            Pop();
        }

        private void SkipAction()
        {
            Pop();
        }
    }
}