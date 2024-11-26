using System;
using UnityEngine;

namespace _ProjectTemplate.Scripts.Base
{
    public abstract class LevelBase : MonoBehaviour
    {
        #region Init

        public void Awake()
        {
            InitLevel();
        }

        private void OnDestroy()
        {
            DestroyLevel();
        }

        public virtual void InitLevel()
        {
        }

        public virtual void DestroyLevel()
        {
        }
        
        public virtual void StartLevel()
        {
        }

        public virtual void EndLevel()
        {
        }

        

        #endregion

        #region Game State

        public virtual void Pause()
        {
        }

        public virtual void Resume()
        {
        }

        public virtual void Victory()
        {
        }

        public virtual void Fail()
        {
        }

        public virtual void Restart()
        {
        }

        #endregion
    }
}