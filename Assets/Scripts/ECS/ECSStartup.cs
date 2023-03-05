using Zenject;
using Entitas;
namespace Core.ECS
{
    public sealed class ECSStartup : IInitializable, ITickable
    {
        private readonly Systems _allSystems;
        public ECSStartup() 
        {
            
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
        public void Tick()
        {
            throw new System.NotImplementedException();
        }
    }
}