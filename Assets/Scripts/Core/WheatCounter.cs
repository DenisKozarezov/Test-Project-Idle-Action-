using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core.Models;
using Core.ECS.Behaviours;

namespace Core.UI
{
    public sealed class WheatCounter : EntityBehaviour, IAnyStackObtainedListener
    {
        [SerializeReference]
        private TextMeshProUGUI _text;
        [SerializeReference]
        private Image _background;
        [SerializeReference]
        private GameConfig _config;

        private void Start()
        {
            RegisterListeners();
            SetFillAmount(0f);
            SetCounter(0, _config.MaxWheatStacks);
        }
        private void OnDestroy() => UnregisterListeners();

        public void RegisterListeners()
        {
            Entity.AddAnyStackObtainedListener(this);
        }
        public void UnregisterListeners()
        {
            Entity.RemoveAnyStackObtainedListener(this);
        }
        private void SetCounter(byte currentValue, byte maxValue)
        {
            _text.text = string.Concat(currentValue.ToString(), "/", maxValue.ToString());
        }
        private void SetFillAmount(float fillAmount)
        {
            _background.fillAmount = fillAmount;
        }
        public void OnAnyStackObtained(GameEntity entity)
        {
            float fillAmount = (float)entity.currentWheatStacks.Value / entity.maxWheatStacks.Value;
            SetFillAmount(fillAmount);
            SetCounter(entity.currentWheatStacks.Value, entity.maxWheatStacks.Value);
        }
    }
}