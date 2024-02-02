using System;
using System.Collections;
using System.Collections.Generic;
using Minions;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TowerDefense
{

    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private WaveGr m_CurWave;
        [SerializeField] private int m_CurWaveIndex = 0;
        [SerializeField] private int m_indexWave;
        [SerializeField] private SpawnComponent m_spawnComponent;
        [SerializeField] private List<WaveGr> m_waveGrs;
        [SerializeField] private List<MinionType> m_minions;
        [SerializeField] private List<BaseMinion> m_AllMinions;

        private void Start()
        {
            m_CurWave = m_waveGrs[m_CurWaveIndex];
            ConfigurationMinions();
        }

        private void Update()
        {
            if (m_AllMinions.Count <= 0)
            {
                Debug.Log("End wave");
            }
        }

        public void NextWave()
        {
            CheckWave();
            m_indexWave++;
            m_spawnComponent.StartSpawn(m_minions);
          
        }

        private void CheckWave()
        {
            if (m_indexWave == 2)
            {
                ChangeWaveParams();
            }
        }

        private void ChangeWaveParams()
        {
            m_indexWave = 0;
            m_CurWaveIndex++;
            
            if (m_CurWaveIndex >= m_waveGrs.Count)
            {
                return;
            }
            
            m_CurWave = m_waveGrs[m_CurWaveIndex];
            
            ConfigurationMinions();
        }

        private void MinionSpawn(BaseMinion minion)
        {
            m_AllMinions.Add(minion);
        }
        
        private void MinionDespawn(BaseMinion minion)
        {
            m_AllMinions.Remove(minion);
        }

        private void ConfigurationMinions()
        {
            m_minions.Clear();
            
            foreach (var obj  in m_CurWave.minioms)
            {
                BaseMinion minion = obj.GetComponent<BaseMinion>();

                minion = SetMinionParametersByWave(minion);
                m_minions.Add(minion.Type);
            }
        }

        public BaseMinion SetMinionParametersByWave(BaseMinion baseMinion)
        {
            switch (baseMinion)

            {
                case ZombiComponent:
                {
                    baseMinion.Damage = m_CurWave.addDamageZomby;
                    baseMinion.Health = m_CurWave.addHealthZomby;
                    baseMinion.Speed = m_CurWave.addMoveZomby;
                    baseMinion.m_isElemental = m_CurWave.isElementalzomby;
                    baseMinion.onSpawn += MinionSpawn;
                    baseMinion.onDied += MinionDespawn;
                    break;
                }

                case SpiderComponent:
                {
                    baseMinion.Damage = m_CurWave.addDamageSpider;
                    baseMinion.Health = m_CurWave.addHealthSpider;
                    baseMinion.Speed = m_CurWave.moveSpider;
                    baseMinion.m_isElemental = m_CurWave.isElementalSpider;
                    baseMinion.onSpawn += MinionSpawn;
                    baseMinion.onDied += MinionDespawn;
                    break;
                }
            }

            return baseMinion;
        }
    }
}