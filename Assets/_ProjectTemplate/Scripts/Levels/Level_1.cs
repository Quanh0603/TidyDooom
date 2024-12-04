using _ProjectTemplate.Scripts.LevelSorting;
using GameTool.Assistants;
using UnityEngine;

namespace _ProjectTemplate.Scripts.Levels
{
    public class Level_1 : LevelSortingBase
    {
        [SerializeField] private LayerMask pickupLayer;

        private ItemSorting currentItem;
        protected Vector2 hitPointOffset;

        private void Start()
        {
            StartLevel();
        }

        public override void StartLevel()
        {
            base.StartLevel();

            AddOnPointerDownHandle();
            AddOnPointerUpHandle();
            AddOnDragHandle();
        }


        public override void EndLevel()
        {
            base.EndLevel();

            RemoveAllAction();
        }

        protected override void OnPointerDownHandle()
        {
            base.OnPointerDownHandle();

            // Check logic nhấn xuống
            var hits = GetAllRaycastHit(pickupLayer);
            if (hits.Length > 0)
            {
                RaycastHit2D hit = hits[0];
                ItemSorting select = hits[0].transform.GetComponent<ItemSorting>();
                for (int i = 0; i < hits.Length; i++)
                {
                    var item = hits[i].transform.GetComponent<ItemSorting>();
                    if (item != null)
                    {
                        select = item;
                        hit = hits[i];
                    }
                }

                if (select)
                {
                    SelectItem(select);

                    hitPointOffset = (Vector2)currentItem.transform.position - hit.point;
                }
            }
        }

        protected override void OnDragHandle()
        {
            // Check logic khi kéo
            if (!currentItem)
            {
                return;
            }

            SetCurrentItemPositionOnDrag();
        }

        private void SetCurrentItemPositionOnDrag()
        {
            if (!currentItem)
            {
                return;
            }

            var item = currentItem;

            var mousePosition = GetMousePosition() + hitPointOffset;
            var minX = -Utilities.GetBoundMaxOfMainCamera().x +
                       (item.transform.position.x - item.SpriteRenderer.bounds.min.x);
            var maxX = Utilities.GetBoundMaxOfMainCamera().x -
                       (item.SpriteRenderer.bounds.max.x - item.transform.position.x);
            var minY = -Utilities.GetBoundMaxOfMainCamera().y +
                       (item.transform.position.y - item.SpriteRenderer.bounds.min.y);
            var maxY = Utilities.GetBoundMaxOfMainCamera().y -
                       (item.SpriteRenderer.bounds.max.y - item.transform.position.y);

            mousePosition.x = Mathf.Clamp(mousePosition.x, minX, maxX);
            mousePosition.y = Mathf.Clamp(mousePosition.y, minY, maxY);
            currentItem.SetPosition(mousePosition);
        }

        protected override void OnPointerUpHandle()
        {
            if (!currentItem)
            {
                return;
            }
            // Check logic thả ra

            UnselectItem();
        }


        private void SelectItem(ItemSorting select)
        {
            currentItem = select;
            if (currentItem)
            {
                currentItem.OnSelected();
            }
        }

        private void UnselectItem()
        {
            if (currentItem)
            {
                currentItem.OnUnselected();
            }

            currentItem = null;
        }
    }
}