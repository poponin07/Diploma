using System;

namespace TowerDefense.DynamicPool
{
    public interface IDynamicPool
    {
        public IPooledObject GetFromPool(MinionType type, Func<IPooledObject> createMethod);
        public void Release(MinionType type, IPooledObject objectToRelease);
    }
}