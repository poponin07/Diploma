using System;
using System.Collections.Generic;

namespace TowerDefense.DynamicPool
{
    public class DynamicPool : IDynamicPool
    {
        //private Stack<IPooledObject> m_objectPool = new Stack<IPooledObject>();
        private Dictionary<MinionType, Stack<IPooledObject>> m_allPools = new Dictionary<MinionType, Stack<IPooledObject>>();

        public IPooledObject GetFromPool(MinionType type, Func<IPooledObject> createMethod)
        {
            var targetPool = GetPoolOfType(type);
            if (targetPool.TryPop(out IPooledObject result))
            {
                result.OnGetFromPool();
                return result;
            }
       
            var pooledObject = createMethod();
            pooledObject.OnGetFromPool();
            return pooledObject;
        }

        public void Release(MinionType type, IPooledObject objectToRelease)
        {
            objectToRelease.OnRelease();
            GetPoolOfType(type).Push(objectToRelease);
        }

        private Stack<IPooledObject> GetPoolOfType(MinionType type)
        {
            var targetPool = new Stack<IPooledObject>();
            if (m_allPools.TryGetValue(type, out Stack<IPooledObject> pool))
            {
                targetPool = pool;
            }
            else
            {
                m_allPools.Add(type, targetPool);
            }

            return targetPool;
        }
    }
}