using UnityEngine;
using TMPro;
using Core.ECS.Behaviours;

namespace Core.UI
{
    public sealed class MoneyCounter : EntityBehaviour, IAnyBroughtStacksListener
    {
        [SerializeReference]
        private TextMeshProUGUI _text;

        private void Start()
        {
            Entity.AddAnyBroughtStacksListener(this);
        }
        private void OnDestroy()
        {
            Entity.RemoveAnyBroughtStacksListener();
        }

        public void OnAnyBroughtStacks(GameEntity entity)
        {
            SetMoney(entity.currentMoney.Value);
        }

        public void SetMoney(int value)
        {
            _text.text = value.ToString();
        }
    }
}