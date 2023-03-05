using Zenject;
using Core.Input;

namespace Core.Infrastructure.Installers
{
    internal sealed class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputSystem>().To<JoystickInput>().AsSingle();
        }
    }
}