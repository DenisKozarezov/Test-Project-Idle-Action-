using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace Core
{
    public sealed class JoystickHandle : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeReference]
        private RawImage _placeholder;
        [SerializeReference]
        private RawImage _handle;
        [SerializeField, Range(0f, 5f)]
        private float _moveRadius;

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
            Vector2 offset = eventData.position - _handle.rectTransform.anchoredPosition;
            _handle.rectTransform.anchoredPosition = _handle.rectTransform.anchoredPosition + Vector2.ClampMagnitude(offset, _moveRadius);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            _handle.transform.localPosition = Vector3.zero;
        }
    }
}
