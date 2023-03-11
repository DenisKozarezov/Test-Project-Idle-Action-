using System.Collections.Generic;
using Core.ECS.ViewListeners;

namespace Core.Services
{
    public sealed class UnityCollisionRegistry : IRegisterService<IViewController>
    {
        private readonly Dictionary<int, IViewController> _allControllersById 
            = new Dictionary<int, IViewController>();

        public IViewController Register(int instanceId, IViewController viewController)
        {
            if (!_allControllersById.ContainsKey(instanceId))
            {
                _allControllersById.Add(instanceId, viewController);
                return viewController;
            }
            return null;
        }
        public void Unregister(int instanceId)
        {
            if (_allControllersById.ContainsKey(instanceId))
            {
                _allControllersById.Remove(instanceId);
            }
        }
        public IViewController Take(int key)
        {
            if (_allControllersById.TryGetValue(key, out IViewController behaviour))
            {
                return behaviour;
            }
            return null;
        }
    }
}