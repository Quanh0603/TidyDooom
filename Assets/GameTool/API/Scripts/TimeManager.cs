using System.Collections.Generic;
using System.Linq;
using GameTool.Assistants.DesignPattern;
using UnityEngine;

namespace GameTool.API.Scripts
{
    public class TimeManager : SingletonMonoBehaviour<TimeManager>
    {
        public List<float> _listTime;

        public void Add(float value)
        {
            _listTime.Add(value);
            CheckTimeScale();
        }

        public void Remove(float value)
        {
            _listTime.Remove(value);
            CheckTimeScale();
        }

        public void CheckTimeScale()
        {
            if (_listTime.Count > 0)
            {
                Time.timeScale = _listTime.Min();
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}