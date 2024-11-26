#if !Minify
using GameTool.Assistants.DesignPattern;
using GameTool.UI.Scripts.CanvasPopup;
using GameToolSample.GameDataScripts.Scripts;
using GameToolSample.Scripts.Enum;
using GameToolSample.UIManager;
using UnityEngine;
using static GameToolSample.Scripts.Enum.AnalyticID;

namespace GameToolSample.GamePlay.Manager
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [Header("COMPONENT")] public GamePlayState GameplayStatus = GamePlayState.none;

        protected virtual void Start()
        {
            PlayGame();
        }

        public bool IsGamePlayStatus(GamePlayState gamePlayState)
        {
            return GameplayStatus == gamePlayState;
        }

        #region STATUS INGAME

        public virtual void PlayGame()
        {
            GameplayStatus = GamePlayState.playing;
        }

        public virtual void Victory()
        {
            GameplayStatus = GamePlayState.victory;
            GameData.Instance.CurrentLevel++;
            ShowVictoryPopup();
        }

        protected virtual void ShowVictoryPopup()
        {
            CanvasManager.Instance.Push(eUIName.VictoryPopup);
        }

        public virtual void Lose()
        {
            GameplayStatus = GamePlayState.lose;
            ShowLosePopup();
        }

        protected virtual void ShowLosePopup()
        {
        }

        public virtual void CheckRevive()
        {
            if (GameplayStatus == GamePlayState.revive) return;
            GameplayStatus = GamePlayState.revive;
            Revive();
        }

        public virtual void Revive()
        {
            GameplayStatus = GamePlayState.playing;
            this.PostEvent(EventID.PlayerRevive);
        }

        protected virtual void ShowRevivePopup()
        {
            CanvasManager.Instance.Push(eUIName.RevivePopup);
        }

        public virtual void SkipLevel()
        {
            GameData.Instance.CurrentLevel++;
        }

        public virtual void ReplayLevel()
        {
        }

        #endregion
    }
}

#endif