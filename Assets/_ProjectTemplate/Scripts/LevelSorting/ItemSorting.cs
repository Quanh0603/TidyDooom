using System;
using _ProjectTemplate.Scripts.Base;
using UnityEditor;
using UnityEngine;

namespace _ProjectTemplate.Scripts.LevelSorting
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ItemSorting : ItemBase
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private Collider2D colliderObj;

        public SpriteRenderer SpriteRenderer => spriteRenderer;

        public Collider2D ColliderObj => colliderObj;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = GetComponent<SpriteRenderer>();
            }

            if (colliderObj == null)
            {
                colliderObj = GetComponent<Collider2D>();
            }

            EditorUtility.SetDirty(this);
        }
#endif
    }
}