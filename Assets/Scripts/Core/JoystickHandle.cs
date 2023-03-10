using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using Core.ECS.Behaviours;

namespace Core
{
    public sealed class JoystickHandle : EntityBehaviour, IDragHandler, IEndDragHandler, IGameAnyTouchClickListener
    {
        [SerializeReference]
        private CanvasGroup _canvasGroup;
        [SerializeReference]
        private RawImage _placeholder;
        [SerializeReference]
        private RawImage _handle;
        [SerializeField, Range(0f, 5f)]
        private float _moveRadius;

        private bool _alreadyTouched;

        private void Start()
        {
            Entity.AddGameAnyTouchClickListener(this);
            Fade(true, 0f);
        }
        private void Fade(bool isFade, float duration = 1f)
        {
            float alpha = isFade ? 0f : 1f;

            _canvasGroup.interactable = false;
            DOTween.To(() => _canvasGroup.alpha, (x) => _canvasGroup.alpha = x, alpha, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    if (!isFade) _canvasGroup.interactable = true;
                    else _alreadyTouched = false;
                });
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 offset = eventData.position - _handle.rectTransform.anchoredPosition;
            _handle.rectTransform.anchoredPosition = _handle.rectTransform.anchoredPosition + Vector2.ClampMagnitude(offset, _moveRadius);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            _handle.rectTransform.localPosition = Vector3.zero;
            Fade(true);
        }
        public void OnAnyTouchClick(GameEntity entity, Vector2 position)
        {
            if (!_alreadyTouched)
            {
                _alreadyTouched = true;
                _placeholder.rectTransform.position = position;
                Fade(false);
            }
        }
    }
}
