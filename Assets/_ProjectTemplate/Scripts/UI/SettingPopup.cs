using System;
using GameTool.UI.Scripts.CanvasPopup;
using UnityEngine;
using UnityEngine.UI;

namespace _ProjectTemplate.Scripts.UI
{
    public class SettingPopup : SingletonUI<SettingPopup>
    {
        [SerializeField] private Button closeBtn;

        private void Start()
        {
            closeBtn.onClick.AddListener(CloseAction);
        }

        private void CloseAction()
        {
            Pop();
        }
    }
}