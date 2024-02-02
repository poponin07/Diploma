namespace TowerDefense.DynamicPool
{
    public interface IPooledObject
    {
        public void OnGetFromPool();
        public void OnRelease();
    }
}