using System;
using Minions;
using UnityEngine;

namespace TowerDefense.DynamicPoolTests
{
    public class PoolingTestBehaviour : MonoBehaviour
    {
        public ZombiComponent zombieTemplate;
        public SpiderComponent spiderTemplate;
        private DynamicPool.DynamicPool m_enemyPool = new DynamicPool.DynamicPool();
        
        private void Start()
        {
            // var zombie = m_enemyPool.GetFromPool(CreateZombie);
        }

        private ZombiComponent CreateZombie()
        {
            var zombie = Instantiate(zombieTemplate, Vector3.zero, Quaternion.identity);
            return zombie;
        }
        private SpiderComponent CreateSpider()
        {
            var spider = Instantiate(spiderTemplate, Vector3.zero, Quaternion.identity);
            return spider;
        }
    }
}