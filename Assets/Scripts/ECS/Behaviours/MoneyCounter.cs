using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Core.ECS.Behaviours
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class MoneyCounter : EntityBehaviour, IAnyBroughtStacksListener
    {
        [SerializeReference]
        private TextMeshProUGUI _text;

        private Tweener _tweener;
        private bool IsPlaying => _tweener != null && _tweener.IsActive() && _tweener.IsPlaying();

        private void Start()
        {
            Entity.isMoneyCounter = true;
            Entity.AddTransform(GetComponent<RectTransform>());
            Entity.AddAnyBroughtStacksListener(this);
        }
        private void OnDestroy()
        {
            Entity.RemoveAnyBroughtStacksListener();
        }
        public void OnAnyBroughtStacks(GameEntity entity)
        {
            AddMoney(entity.currentMoney.Value, entity.potentialMoney.Value);
        }

        private void SetText(int value)
        {
            _text.text = value.ToString();
        }
        private void AddMoney(int currentValue, int addingValue)
        {
            if (addingValue == 0) return;

            if (IsPlaying) _tweener?.Kill();

            _tweener = DOTween.To(() => currentValue, (x) => SetText(x), currentValue + addingValue, 1.5f)
                .SetEase(Ease.Linear);
        }
    }
}