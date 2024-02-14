using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Minions;
using UnityEngine;
using Waves;
using Debug = UnityEngine.Debug;

namespace TowerDefense
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform m_spawnPointTransform;
        [SerializeField] private Transform path;
        [SerializeField] private List<Transform> m_path;
        [SerializeField] private WaveManager m_waveManager;
        [SerializeField] private ZombiComponent m_zombieTemplate;
        [SerializeField] private SpiderComponent m_spiderTemplate;
        [SerializeField] private PlayerData m_playerData;

        private float m_spawnOffset;
        private int m_currentWave;
        private DynamicPool.DynamicPool m_dynamicPool = new DynamicPool.DynamicPool();

        private Dictionary<MinionType, int> m_typeMultipliers = new Dictionary<MinionType, int>()
        {
            {MinionType.Zomby, 2},
            {MinionType.Spider, 1}
        };
        
        private Coroutine spawnCor;

        private void Start()
        {
            var myArray = path.GetComponentsInChildren<Transform>();
            m_path = myArray.ToList();
            m_path.Remove(m_path[0]);

            m_spawnOffset = 0.2f;
        }
        
        public void StartSpawn(List<MinionType> minions)
        {
            m_currentWave++;
            var waveDesc = CreateWaveDesc(minions);
            var waveEnemies = GetWaveEnemies(waveDesc);
            StartCoroutine(SpawnOffset(waveEnemies));
        }


        IEnumerator SpawnOffset(List<BaseMinion> spawnList)
        {
            foreach (var minion in spawnList)
            {
                yield return new WaitForSeconds(m_spawnOffset);
                InitMinionOnPosition(minion);
            }
        }

        private void InitMinionOnPosition(BaseMinion minion)
        {
            m_waveManager.SetMinionParametersByWave(minion);
            MinoinMoveController moveComponent = minion.gameObject.GetComponent<MinoinMoveController>();
            moveComponent.SetTarget();
            moveComponent.SetRunIndex(-1);
            minion.transform.position = m_spawnPointTransform.position;
            moveComponent.m_points = m_path;
            minion.gameObject.SetActive(true);
            minion.Spawn();
        }

        private List<BaseMinion> CreateEnemiesByType(MinionType type, int count)
        {
            var result = new List<BaseMinion>(count);
            Func<BaseMinion> createMethod = null;
            
            switch (type)
            {
                case MinionType.Zomby:
                    createMethod = CreateZombie;
                    break;
            
                case MinionType.Spider:
                    createMethod = CreateSpider;
                    break;
            }

            if (createMethod == null)
            {
                Debug.LogError("Method for create " + type + " does not exist!!!");
            }
            
            for (int i = 0; i < count; i++)
            {
               result.Add((BaseMinion)m_dynamicPool.GetFromPool(type, createMethod));
            }

            return result;
        }

        private ZombiComponent CreateZombie()
        {
            var result = Instantiate(m_zombieTemplate, m_spawnPointTransform.position, Quaternion.identity);
            BaseMinion baseMinion = result.GetComponent<BaseMinion>();
            result.gameObject.SetActive(false);
            result.onDied += OnDied;
            baseMinion.onSpawn += m_waveManager.MinionSpawn;
            baseMinion.onDied += m_waveManager.MinionDespawn;
            baseMinion.onScore += m_playerData.SetScoreAndCoin;
            return result;
        }

        private SpiderComponent CreateSpider()
        {
            var result = Instantiate(m_spiderTemplate, m_spawnPointTransform.position, Quaternion.identity);
            BaseMinion baseMinion = result.GetComponent<BaseMinion>();
            result.gameObject.SetActive(false);
            result.onDied += OnDied;
            baseMinion.onSpawn += m_waveManager.MinionSpawn;
            baseMinion.onDied += m_waveManager.MinionDespawn;
            baseMinion.onScore += m_playerData.SetScoreAndCoin;
            return result;
        } 

        private void OnSpawn(BaseMinion minion)
        {
            
        }
        private void OnDied(BaseMinion minion)
        {
           //minion.onSpawn -= m_waveManager.MinionSpawn;
            //minion.onDied -= m_waveManager.MinionDespawn;
            //minion.onScore -= m_playerData.SetScoreAndCoin;
            //minion.onDied -= OnDied;
            m_dynamicPool.Release(minion.Type, minion);
        }
        
        private List<BaseMinion> GetWaveEnemies(Dictionary<MinionType, int> waveDesc)
        {
            List<BaseMinion> spawnList = new List<BaseMinion>();

            foreach (var typePair in waveDesc)
            {
                spawnList.AddRange(CreateEnemiesByType(typePair.Key, typePair.Value));
            }

            return spawnList;
        }

        private Dictionary<MinionType, int> CreateWaveDesc(List<MinionType> minionTypes)
        {
            var resultDesc = new Dictionary<MinionType, int>();
            
            foreach (var type in minionTypes)
            {
                if (m_typeMultipliers.TryGetValue(type, out int multiplier))
                {
                    resultDesc.Add(type, m_currentWave * multiplier);
                }
            }

            return resultDesc;
        }
    }
}