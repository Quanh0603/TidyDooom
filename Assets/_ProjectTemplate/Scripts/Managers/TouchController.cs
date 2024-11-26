using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _ProjectTemplate.Scripts.Managers
{
    public class TouchController : MonoBehaviour, IPointerClickHandler, IDragHandler, IPointerUpHandler,
        IPointerDownHandler
    {
        public static Action OnPointerClickHandle;
        public static Action OnPointerDownHandle;
        public static Action OnPointerUpHandle;
        public static Action OnDragHandle;

        public static bool IsActive;

        private void Start()
        {
#if UNITY_EDITOR
            TouchController.IsActive = true;
#endif


            TouchController.IsActive = true;
        }


        public static void RemoveAllTouch()
        {
            OnPointerClickHandle = null;
            OnPointerDownHandle = null;
            OnPointerUpHandle = null;
            OnDragHandle = null;
        }

        public void OnTimeUp()
        {
            OnPointerUp(null);
            IsActive = false;
        }

        public void Revive()
        {
            IsActive = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (IsActive)
                OnDragHandle?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (IsActive)
                OnPointerClickHandle?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (IsActive)
                OnPointerUpHandle?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (IsActive)
                OnPointerDownHandle?.Invoke();
        }
    }
}