using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Core.ECS.Behaviours;

namespace Core
{
    public interface IWheatStacksFactory : IFactory<Vector3, WheatStackBehaviour> 
    {
        void Clear();
    }

    public class WheatStacksFactory : PlaceholderFactory<Vector3, WheatStackBehaviour>, IWheatStacksFactory 
    {
        private readonly LinkedList<WheatStackBehaviour> _pool;
        private readonly Transform _parent;
        public WheatStacksFactory()
        {
            _pool = new LinkedList<WheatStackBehaviour>();
            _parent = new GameObject("Wheat Stacks Pool").transform;
        }

        public override WheatStackBehaviour Create(Vector3 param)
        {
            WheatStackBehaviour stack = base.Create(param);
            stack.transform.SetParent(_parent, true);
            _pool.AddLast(stack);
            return stack;
        }
        public void Clear()
        {
            foreach (WheatStackBehaviour stack in _pool)
            {
                stack.transform.SetParent(_parent, true);
                stack.Entity.isDestroyed = true;
            }
            _pool.Clear();
        }
    }
}