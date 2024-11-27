using System.Collections.Generic;
using _ProjectTemplate.Scripts.Managers;
using GameTool.UI.Scripts.CanvasPopup;
using UnityEngine;
using UnityEngine.UI;

namespace _ProjectTemplate.Scripts.UI
{
    public class HintPopup : SingletonUI<HintPopup>
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Button previousButton;
        [SerializeField] private Button nextButton;

        [SerializeField] private Image imageHint;

        private List<Sprite> hintSprites = new List<Sprite>();

        private int currentHintIndex = -1;

        private void Start()
        {
            closeButton.onClick.AddListener(Pop);
            previousButton.onClick.AddListener(OnPreviousHint);
            nextButton.onClick.AddListener(OnNextHint);
        }

        public void SetHint(List<Sprite> sprites)
        {
            hintSprites = new List<Sprite>();
            hintSprites = sprites;
        }

        private void ValidateNavigateButton()
        {
            previousButton.gameObject.SetActive(currentHintIndex != 0);

            nextButton.gameObject.SetActive(currentHintIndex != hintSprites.Count - 1);
        }

        private void ShowHintAtIndex()
        {
            imageHint.sprite = hintSprites[currentHintIndex];
        }

        private void OnEnable()
        {
            currentHintIndex = 0;
            if (hintSprites.Count > 0)
            {
                ShowHintAtIndex();
                ValidateNavigateButton();
            }
            else
            {
                if (previousButton)
                {
                    previousButton.gameObject.SetActive(false);
                }

                if (nextButton)
                {
                    nextButton.gameObject.SetActive(false);
                }
            }
        }

        private void OnNextHint()
        {
            currentHintIndex++;
            ValidateNavigateButton();
            ShowHintAtIndex();
        }

        private void OnPreviousHint()
        {
            currentHintIndex--;
            ValidateNavigateButton();
            ShowHintAtIndex();
        }

        public override void Init(params object[] args)
        {
            base.Init(args);
            GameController.Instance.PauseGame();
        }

        public override void Pop()
        {
            base.Pop();

            GameController.Instance.ResumeGame();
        }
    }
}