using System;
using System.Collections;
using GameTool.Assistants.DesignPattern;
using GameToolSample.GameDataScripts.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace GameTool.API.Scripts
{
    public class API : SingletonMonoBehaviour<API>
    {
        protected bool _isFirstOpenTime;
        protected bool _apiStarted;

        [SerializeField] protected GameObject loadingObj;
        [SerializeField] protected Text loadingInfoText;

        public virtual bool FirstOpen
        {
            get => GameData.Instance.FirstOpen;
            set => GameData.Instance.FirstOpen = value;
        }

        public bool IsFirstOpenTime => _isFirstOpenTime;

        public virtual bool APIStarted => _apiStarted;


        protected override void Awake()
        {
            // Lấy các settings của API
            base.Awake();
            InitSettings();
        }

        protected virtual void Start()
        {
            Application.targetFrameRate = 60;
            ActiveLoading(false);

            StartAPI();
        }

        private void StartAPI()
        {
            StartCoroutine(nameof(WaitDataStart));
        }

        public virtual void InitSettings()
        {
        }


        //Load các Data đã lưu trong máy, set các biến check cần thiết cho các script khác trong game cần dùng
        private IEnumerator WaitDataStart()
        {
            yield return new WaitUntil(() => GameData.allDataLoaded);

            if (!FirstOpen)
            {
                FirstOpen = true;
                _isFirstOpenTime = true;
            }

            _apiStarted = true;
        }

        #region Utility

        public void ShowLoading(Action onClosed)
        {
            ActiveLoading(true);
            onClosed?.Invoke();
        }

        public bool HasTurnOffInternet()
        {
#if UNITY_EDITOR
            return false;
#else
            return InternetChecker.SHasTurnOffInternet();
#endif
        }

        public static bool IsEditor()
        {
            if (Application.platform == RuntimePlatform.WindowsEditor ||
                Application.platform == RuntimePlatform.OSXEditor)
                return true;
            return false;
        }

        public static bool IsAndroid()
        {
#if UNITY_ANDROID
            return true;
#else
            return false;
#endif
        }

        public static bool IsIOS()
        {
#if UNITY_IOS
            return true;
#else
            return false;
#endif
        }

        #endregion

        #region LOADING

        public void ActiveLoading(bool active, string info = "LOADING...")
        {
            loadingObj.SetActive(active);
            SetLoadingInfoText(info);
        }

        public void SetLoadingInfoText(string info = "LOADING...")
        {
            loadingInfoText.text = info;
        }

        public void DisableLoadingWithTime(float time = 0.5f)
        {
            StopCoroutine(nameof(WaitDisableLoading));
            StartCoroutine(nameof(WaitDisableLoading), time);
        }

        private IEnumerator WaitDisableLoading(float time = 0.5f)
        {
            yield return new WaitForSeconds(time);
            loadingObj.SetActive(false);
        }

        #endregion
    }
}