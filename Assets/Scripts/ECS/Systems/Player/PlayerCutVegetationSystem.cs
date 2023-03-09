using System.Collections.Generic;
using UnityEngine;
using Entitas;
using EzySlice;

namespace Core.ECS.Systems
{
    public sealed class PlayerCutVegetationSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _players;
        public PlayerCutVegetationSystem(GameContext game) : base(game)
        {
            _players = game.GetGroup(GameMatcher.Player);
        }

        private void GenerateShatter(GameObject shatteredObj)
        {
            shatteredObj.layer = Constants.IgnoreRaycastLayer;
            
            float factor = Random.Range(0f, 1f);
            Vector3 force = Vector3.Lerp(Vector3.up, Vector3.right, factor) * 5f;

            shatteredObj.AddComponent<SphereCollider>();
            shatteredObj.AddComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);

            GameObject.Destroy(shatteredObj, 2f);
        }
        private void SliceObject(GameEntity entity, Vector3 slicePosition, Vector3 sliceDirection)
        {
            foreach (var slice in entity.transform.Value.GetComponentsInChildren<MeshFilter>())
            {
                GameObject source = slice.gameObject;
                SlicedHull hull = source.Slice(slicePosition, sliceDirection);

                if (hull != null)
                {
                    GameObject upperHull = hull.CreateUpperHull(source);
                    upperHull.transform.localPosition = slicePosition;                                 
                    GenerateShatter(upperHull);

                    GameObject lowerHull = hull.CreateLowerHull(source);
                    lowerHull.transform.localPosition = slicePosition;
                    GenerateShatter(lowerHull);

                    entity.isDestroyed = true;
                }
            }
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Collided.Added());
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.isVegetation && !entity.hasIsGrowing;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                foreach (GameEntity player in _players)
                {
                    entity.isCanBeSliced = false;
                    entity.ReplaceIsGrowing(entity.regenerationTime.Value);

                    ref Vector3 slicePosition = ref entity.collisionContact.Point;
                    Transform transform = player.transform.Value;
                    player.isAttacking = true;

                    SliceObject(entity, slicePosition, transform.forward);
                }
            }
        } 
    }
}
