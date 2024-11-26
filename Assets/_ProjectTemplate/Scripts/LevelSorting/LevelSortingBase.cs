using _ProjectTemplate.Scripts.Base;
using _ProjectTemplate.Scripts.Managers;
using UnityEngine;

namespace _ProjectTemplate.Scripts.LevelSorting
{
    public class LevelSortingBase : LevelBase
    {
        #region Touch Controller

        protected void AddOnPointerDownHandle()
        {
            TouchController.OnPointerDownHandle -= OnPointerDownHandle;
            TouchController.OnPointerDownHandle += OnPointerDownHandle;
        }

        protected void AddOnPointerUpHandle()
        {
            TouchController.OnPointerUpHandle -= OnPointerUpHandle;
            TouchController.OnPointerUpHandle += OnPointerUpHandle;
        }

        protected void AddOnDragHandle()
        {
            TouchController.OnDragHandle -= OnDragHandle;
            TouchController.OnDragHandle += OnDragHandle;
        }

        protected void AddOnPointerClickHandle()
        {
            TouchController.OnPointerClickHandle -= OnPointerClickHandle;
            TouchController.OnPointerClickHandle += OnPointerClickHandle;
        }

        public void RemoveAllAction()
        {
            RemoveOnPointerDownHandle();
            RemoveOnPointerUpHandle();
            RemoveOnDragHandle();
            RemoveOnPointerClickHandle();
        }

        public void AddAllAction()
        {
            AddOnPointerDownHandle();
            AddOnPointerUpHandle();
            AddOnDragHandle();
            AddOnPointerClickHandle();
        }

        protected void RemoveOnPointerDownHandle()
        {
            TouchController.OnPointerDownHandle -= OnPointerDownHandle;
        }

        protected void RemoveOnPointerUpHandle()
        {
            TouchController.OnPointerUpHandle -= OnPointerUpHandle;
        }

        protected void RemoveOnDragHandle()
        {
            TouchController.OnDragHandle -= OnDragHandle;
        }

        protected void RemoveOnPointerClickHandle()
        {
            TouchController.OnPointerClickHandle -= OnPointerClickHandle;
        }


        protected virtual void OnPointerDownHandle()
        {
        }

        protected virtual void OnPointerUpHandle()
        {
        }

        protected virtual void OnDragHandle()
        {
        }

        protected virtual void OnPointerClickHandle()
        {
        }

        #endregion

        #region API

        public override void EndLevel()
        {
            RemoveAllAction();

            //TODO: Gọi tạm win
            Victory();
        }

        /// Lấy vị trí của con trỏ chuột trong không gian thế giới
        public Vector2 GetMousePosition()
        {
            // ReSharper disable once PossibleNullReferenceException
            Vector2 screenToWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return screenToWorldPoint;
        }

        /// Thực hiện Raycast từ vị trí chuột và chỉ kiểm tra các đối tượng trên các layer được chọn
        public RaycastHit2D GetRaycastHit(LayerMask mask)
        {
            RaycastHit2D hit = Physics2D.Raycast(GetMousePosition(), Vector2.zero, Mathf.Infinity, mask);
            return hit;
        }

        public RaycastHit2D GetRaycastHit(Vector2 position, LayerMask mask)
        {
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero, Mathf.Infinity, mask);
            return hit;
        }

        public RaycastHit2D[] GetAllRaycastHit(LayerMask mask)
        {
            // ReSharper disable once Unity.PreferNonAllocApi
            RaycastHit2D[] results = Physics2D.RaycastAll(GetMousePosition(), Vector2.zero, Mathf.Infinity, mask);
            return results;
        }

        public RaycastHit2D[] GetAllRaycastHit(Vector2 pos, LayerMask mask)
        {
            // ReSharper disable once Unity.PreferNonAllocApi
            RaycastHit2D[] results = Physics2D.RaycastAll(pos, Vector2.zero, Mathf.Infinity, mask);
            return results;
        }

        #endregion
    }
}