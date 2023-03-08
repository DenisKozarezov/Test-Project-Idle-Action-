using UnityEngine;
using Zenject;
using Core.Services;
using Core.ECS;
using Core.ECS.Behaviours;

namespace Core.Infrastructure.Installers
{
    internal sealed class GameInstaller : MonoInstaller
    {
        [SerializeReference]
        private GameObject _wheatStackPrefab; 

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<JoystickInput>().AsSingle();
            Container.BindInterfacesTo<ECSStartup>().AsSingle().NonLazy();

            BindPools();
        }

        private void BindPools()
        {
            Container.BindFactory<Vector3, WheatStackBehaviour, WheatStackBehaviour.Factory>()
               .FromMonoPoolableMemoryPool(x => x
               .WithInitialSize(10)
               .FromComponentInNewPrefab(_wheatStackPrefab)
               .UnderTransformGroup("Wheat Stacks"));
        }
    }
}