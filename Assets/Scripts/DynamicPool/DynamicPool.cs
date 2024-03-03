﻿using System;
using System.Collections.Generic;
using TowerDefense;
using TowerDefense.DynamicPool;

namespace DynamicPool
{
    public class DynamicPool : IDynamicPool
    {
        private Dictionary<MinionType, Stack<IPooledObject>> m_allPools = new ();
        public IPooledObject GetFromPool(MinionType type, Func<IPooledObject> createMethod)
        {
            var targetPool = GetPoolOfType(type);
            if (targetPool.TryPop(out IPooledObject result))
            {
                result.OnGetFromPool();
                return result;
            }
       
            IPooledObject pooledObject = createMethod();
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