using Zenject;
using Core.Services;
using Core.ECS;

namespace Core.Infrastructure.Installers
{
    internal sealed class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputService>().To<JoystickInput>().AsSingle();
            Container.BindInterfacesTo<ECSStartup>().AsSingle().NonLazy();
        }
    }
}