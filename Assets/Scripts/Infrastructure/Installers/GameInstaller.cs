using UnityEngine;
using Zenject;
using Core.Services;
using Core.ECS;
using Core.ECS.Behaviours;
using Core.Models;

namespace Core.Infrastructure.Installers
{
    internal sealed class GameInstaller : MonoInstaller
    {
        [SerializeReference]
        private GameConfig _config;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<JoystickInput>().AsSingle();
            Container.BindInterfacesTo<ECSStartup>().AsSingle().NonLazy();

            BindPools();
        }

        private void BindPools()
        {
            Container.BindFactoryCustomInterface<Vector3, WheatStackBehaviour, WheatStacksFactory, IWheatStacksFactory>()
               .FromMonoPoolableMemoryPool(x => x
               .WithInitialSize(_config.WheatStacksPoolCapacity)
               .FromComponentInNewPrefab(_config.WheatStackPrefab)
               .UnderTransformGroup("Wheat Stacks Pool"));

            Container.BindFactory<RectTransform, CoinsFactory>()
                .FromComponentInNewPrefab(_config.CoinPrefab);
        }
    }
}