using UnityEngine;
using Zenject;
using Core.ECS.Behaviours;

namespace Core
{
    public interface IWheatStacksFactory : IFactory<Vector3, WheatStackBehaviour> { }

    public class WheatStacksFactory : PlaceholderFactory<Vector3, WheatStackBehaviour>, IWheatStacksFactory { }
}