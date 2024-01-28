using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private WaveGr m_CurWave;
        [SerializeField] private int m_CurWaveIndex = 0;
        [SerializeField] private int m_indexWave;
        [SerializeField] private SpawnComponent m_spawnComponent;
        [SerializeField] private List<WaveGr> m_waveGrs;
        [SerializeField] private List<GameObject> m_minions;

        private void Start()
        {
            m_CurWave = m_waveGrs[m_CurWaveIndex];
            ConfigurationMinions();
            //NextWave();
        }

        public void NextWave()
        {
            CheckWave();
            m_indexWave++;
            m_spawnComponent.StartSwawn(m_minions);
          
        }

        private void CheckWave()
        {
            if (m_indexWave == 2)
            {
                ChangeWaveParams();
            }
        }

        private void GetMinionsWaveData()
        {
            foreach (var VARIABLE in m_CurWave.minioms)
            {
                
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

        private void ConfigurationMinions()
        {
            m_minions.Clear();
            
            foreach (var obj  in m_CurWave.minioms)
            {
                BaseMinion minion = obj.GetComponent<BaseMinion>();

                switch (minion)
                {
                    case ZombiComponent:
                    {
                        minion.Damage = m_CurWave.addDamageZomby;
                        minion.Health = m_CurWave.addHealthZomby;
                        minion.Speed = m_CurWave.addMoveZomby;
                        minion.m_iselemental = m_CurWave.isElementalzomby;
                        break;
                    } 
                    
                    case SpiderComponent:
                    {
                        minion.Damage = m_CurWave.addDamageSpider;
                        minion.Health = m_CurWave.addHealthSpider;
                        minion.Speed = m_CurWave.moveSpider;
                        minion.m_iselemental = m_CurWave.isElementalSpider;
                        break;
                    } 
                }
                m_minions.Add(obj);
            }
        }
    }
}