using System.Collections;
using GameTool.Assistants.DesignPattern;
using GameToolSample.GameDataScripts.Scripts;
using GameToolSample.Scripts.LoadScene;
using UnityEngine;

namespace GameTool.Assistants
{
    public class SplashSceneManager : SingletonMonoBehaviour<SplashSceneManager>
    {
        [SerializeField] private float maxTimeWaitLoadSceneStart = 1f;

        private bool loadSceneStart = true;

        private void Start()
        {
            StartCoroutine(LoadSceneStart());
        }

        private IEnumerator LoadSceneStart()
        {
            float currentTimeWaitLoadSceneStart = 0f;
            while ((!GameData.allDataLoaded || !API.Scripts.API.Instance.APIStarted) &&
                   (currentTimeWaitLoadSceneStart < maxTimeWaitLoadSceneStart))
            {
                currentTimeWaitLoadSceneStart += Time.unscaledDeltaTime;
                yield return null;
            }

            if (loadSceneStart)
            {
                SceneLoadManager.Instance.LoadSceneStart();
            }
        }
    }
}