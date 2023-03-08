namespace Core.ECS.Behaviours
{
    public sealed class VegetationBehaviour : CollisionEntityBehaviour
    {
        private void Start()
        {
            Entity.isVegetation = true;
            Entity.isCanBeCut = true;
            Entity.AddRegenerationTime(10f);
            Entity.AddTransform(transform);
            Entity.AddPosition(transform.position);
        }
    }
}