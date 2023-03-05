using Entitas;
using Core.Services;

namespace Core.ECS.Systems
{
    public sealed class EmitInputSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IGroup<InputEntity> _leftMouse;
        private readonly IGroup<InputEntity> _rightMouse;
        private readonly IGroup<InputEntity> _keyboard;
        private readonly InputContext _inputContext;

        public EmitInputSystem(InputContext inputContext)
        {
            _inputContext = inputContext;
        }

        public void Initialize()
        {

        }
        public void Execute()
        {
            
        }
    }
}