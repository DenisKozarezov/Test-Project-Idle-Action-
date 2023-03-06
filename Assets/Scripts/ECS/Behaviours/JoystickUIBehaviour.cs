using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.ECS.Behaviours
{
    public sealed class JoystickUIBehaviour : EntityBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeReference]
        private RectTransform _handle;
        [SerializeField, Range(0f, 5f)]
        private float _moveRadius;

        private void Start()
        {
            Entity.isJoystickUI = true;
        }
        public void OnDrag(PointerEventData eventData)
        {
            Vector3 inputPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            Vector3 offset = inputPosition - gameObject.transform.position;

            offset = new Vector3(offset.x, offset.y, 0);

            _handle.gameObject.transform.position = gameObject.transform.position + Vector3.ClampMagnitude(offset, _moveRadius);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            _handle.transform.localPosition = Vector3.zero;
        }
    }
}
