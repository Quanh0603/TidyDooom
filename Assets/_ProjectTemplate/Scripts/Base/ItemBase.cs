using System;
using DG.Tweening;
using GameTool.Assistants;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _ProjectTemplate.Scripts.Base
{
    public abstract class ItemBase : MonoBehaviour
    {
        public virtual void Init()
        {
        }

        public virtual void OnSelected()
        {
        }

        public virtual void OnUnselected()
        {
        }

        #region API

        public void SetEulerAngleZero()
        {
            transform.localEulerAngles = Vector3.zero;
        }

        public void SetEulerAngle(float min, float max)
        {
            var target = Random.Range(min, max) * Utilities.RandomOneOrMinusOne();
            Vector3 desRot = new Vector3(0f, 0f, target);
            transform.localEulerAngles = desRot;
        }

        public void SetEulerAngle(float angle)
        {
            Vector3 desRot = new Vector3(0f, 0f, angle);
            transform.localEulerAngles = desRot;
        }

        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        public void SetLocalPosition(Vector3 pos)
        {
            transform.localPosition = pos;
        }

        public void SetLocalScale(Vector3 scale)
        {
            transform.localScale = scale;
        }


        public void KillDOTween()
        {
            this.DOKill();
        }

        public void DoShake(float duration = 0.2f, float strength = 0.2f, int vibrato = 10, float randomness = 90,
            Action onComplete = null)
        {
            transform.DOShakePosition(duration, strength, vibrato, randomness).OnComplete(() =>
            {
                onComplete?.Invoke();
            }).SetTarget(this);
        }

        public void DOLocalRotate(float angle, float duration = 0.2f, Action completeAction = null)
        {
            Vector3 newRotate = new Vector3(0, 0, angle);
            transform.DOLocalRotate(newRotate, duration).OnComplete(() => { completeAction?.Invoke(); })
                .SetTarget(this);
        }

        public void DOLocalRotate(Vector3 newRotate, float duration = 0.2f, Action completeAction = null)
        {
            transform.DOLocalRotate(newRotate, duration).OnComplete(() => { completeAction?.Invoke(); })
                .SetTarget(this);
        }

        public void DOLocalRotate(float duration = 0.2f, Action completeAction = null)
        {
            transform.DOLocalRotate(Vector3.zero, duration).OnComplete(() => { completeAction?.Invoke(); })
                .SetTarget(this);
        }

        public void DOMove(Vector3 position, float duration = 0.2f, Action completeAction = null)
        {
            transform.DOMove(position, duration).OnComplete(() => { completeAction?.Invoke(); }).SetTarget(this);
        }

        public void MoveAndRotate(Vector3 position, float duration = 0.2f, Action completeAction = null)
        {
            transform.DOLocalRotate(Vector3.zero, duration).SetTarget(this);
            transform.DOMove(position, duration).OnComplete(() => { completeAction?.Invoke(); }).SetTarget(this);
        }

        public void DOLocalMove(Vector3 position, float duration = 0.2f, Action completeAction = null)
        {
            transform.DOLocalMove(position, duration).OnComplete(() => { completeAction?.Invoke(); }).SetTarget(this);
        }

        public void DOScale(Vector3 startScale, Vector3 endScale, float duration = 0.3f)
        {
            SetLocalScale(startScale);
            transform.DOScale(endScale, duration)
                .OnComplete(() => { transform.DOScale(startScale, duration).SetTarget(this); }).SetTarget(this);
        }

        public void DOScale(Vector3 endScale, float duration = 0.2f)
        {
            transform.DOScale(endScale, duration).SetTarget(this);
        }

        public void ScaleZoomIn(float duration = 0.15f)
        {
            transform.DOScale(Vector3.one * 1.1f, duration).SetTarget(this);
        }

        public void ScaleZoomOut(float duration = 0.15f)
        {
            transform.DOScale(Vector3.one, duration).SetTarget(this);
        }

        public void AnimDOScale(float duration = 0.2f)
        {
            var defaultScale = Vector3.one;
            SetLocalScale(defaultScale);
            transform.DOScale(defaultScale * 1.1f, duration / 2f).OnComplete(() =>
            {
                transform.DOScale(defaultScale, duration / 2f)
                    .OnComplete(() => { SetLocalScale(defaultScale); })
                    .SetTarget(this);
            }).SetTarget(this);
        }

        #endregion
    }
}