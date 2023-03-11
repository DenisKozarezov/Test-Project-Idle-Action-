using Zenject;
using Core.ECS.ViewListeners;
using Core.Services;

namespace Core.Infrastructure.Installers
{
    internal sealed class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IRegisterService<IViewController>>().To<UnityCollisionRegistry>().AsSingle().NonLazy();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle().NonLazy();
            Container.Bind<IPhysicsService>().To<UnityPhysicsService>().AsSingle().NonLazy();
            Container.Bind<IIdentifierService>().To<GameIdentifierRegistry>().AsSingle().NonLazy();
        }
    }
}