using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Core
{
    public sealed class JoystickHandle : MonoBehaviour, IAnyTouchClickListener, IAnyStoppedDraggingListener
    {
        [SerializeReference]
        private CanvasGroup _canvasGroup;
        [SerializeReference]
        private RawImage _placeholder;
        [SerializeReference]
        private RawImage _handle;
        [SerializeField, Range(0f, 100f)]
        private float _moveRadius;

        private InputEntity _input;
        private Vector2 _touchClick;
        private bool _alreadyTouched;

        private void Awake()
        {
            _input = ECSExtensions.Input().joystickEntity;
            _input.AddAnyTouchClickListener(this);
            _input.AddAnyStoppedDraggingListener(this);
            Fade(true, 0f);
        }
        private void Update()
        {
            if (!_alreadyTouched) return;

            Vector2 offset = Vector2.ClampMagnitude(_input.touchOffset.Value, _moveRadius);
            _handle.rectTransform.position = _touchClick + offset;
        }
        private void OnDestroy()
        {
            _input.RemoveAnyTouchClickListener(this);
            _input.RemoveAnyStoppedDraggingListener(this);
        }
        private void Fade(bool isFade, float duration = 0.5f)
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
        public void OnAnyTouchClick(InputEntity entity, Vector2 position)
        {
            if (!_alreadyTouched)
            {
                _alreadyTouched = true;
                _touchClick = position;
                _placeholder.rectTransform.position = position;
                Fade(false);
            }
        }
        public void OnAnyStoppedDragging(InputEntity entity)
        {
            _handle.rectTransform.localPosition = Vector3.zero;
            Fade(true);
        }
    }
}
