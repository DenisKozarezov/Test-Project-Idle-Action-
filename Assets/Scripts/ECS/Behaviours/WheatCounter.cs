using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core.Models;

namespace Core.ECS.Behaviours
{
    public sealed class WheatCounter : EntityBehaviour, IAnyStackObtainedListener, IAnySoldListener
    {
        [SerializeReference]
        private TextMeshProUGUI _text;
        [SerializeReference]
        private Image _background;
        [SerializeReference]
        private GameConfig _config;

        private GameEntity _player;

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
            Entity.AddAnySoldListener(this);
        }
        public void UnregisterListeners()
        {
            Entity.RemoveAnyStackObtainedListener(this);
            Entity.RemoveAnySoldListener();
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
            _player = entity;

            float fillAmount = (float)entity.currentWheatStacks.Value / entity.maxWheatStacks.Value;
            SetFillAmount(fillAmount);
            SetCounter(entity.currentWheatStacks.Value, entity.maxWheatStacks.Value);
        }
        public void OnAnySold(GameEntity entity)
        {
            float fillAmount = (float)_player.currentWheatStacks.Value / _player.maxWheatStacks.Value;
            SetFillAmount(fillAmount);
            SetCounter(_player.currentWheatStacks.Value, _player.maxWheatStacks.Value);
        }
    }
}