using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace Core.ECS.Behaviours
{
    public sealed class JoystickUIBehaviour : EntityBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeReference]
        private RawImage _placeholder;
        [SerializeReference]
        private RawImage _handle;
        [SerializeField, Range(0f, 5f)]
        private float _moveRadius;

        private GameEntity _entity;

        private void Fade(bool isFade, float duration = 1f)
        {
            float alpha = isFade ? 0f : 1f;

            Sequence sequence = DOTween.Sequence();
            sequence.Join(_placeholder.DOFade(1f - alpha, duration));
            sequence.Join(_handle.DOFade(1f - alpha, duration));
            sequence.SetEase(Ease.Linear);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 inputPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            Vector3 offset = inputPosition - gameObject.transform.position;

            offset = new Vector3(offset.x, offset.y, 0);

            _handle.rectTransform.position = _handle.rectTransform.position + Vector3.ClampMagnitude(offset, _moveRadius);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            _handle.transform.localPosition = Vector3.zero;
        }
    }
}
