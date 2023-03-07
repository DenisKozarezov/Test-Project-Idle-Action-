using Entitas;
using System.Collections.Generic;

namespace Core.ECS.Systems.Input
{
    public sealed class JoystickStoppedDraggingSystem : ReactiveSystem<InputEntity>
    {
        public JoystickStoppedDraggingSystem(InputContext input) : base(input)
        {

        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.Dragging.Removed());
        }
        protected override bool Filter(InputEntity entity)
        {
            return entity.isJoystick;
        }
        protected override void Execute(List<InputEntity> entities)
        {
            foreach (InputEntity entity in entities)
            {
                entity.isStoppedDragging = true;
            }
        }
    }
}