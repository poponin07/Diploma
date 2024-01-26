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
            NextWave();
        }

        private void NextWave()
        {
            CheckWave();
            m_indexWave++;
            m_spawnComponent.StartSwawn(m_minions);
          
        }

        private void CheckWave()
        {
            if (m_indexWave == 10 || m_indexWave == 0)
            {
                ChangeWaveParams();
            }
        }

        private void ChangeWaveParams()
        {
            m_indexWave = 0;
            m_CurWaveIndex++;
            if (m_CurWaveIndex >= 5)
            {
                return;
            }

            ConfigurationMinions();
        }

        private void ConfigurationMinions()
        {
            foreach (var obj  in m_CurWave.minioms)
            {
                BaseMinion minion = obj.GetComponent<BaseMinion>();

                switch (minion)
                {
                    case ZombiComponent:
                    {
                        minion.Damage += m_CurWave.addDamageZomby;
                        minion.Health += m_CurWave.addHealthZomby;
                        minion.Speed += m_CurWave.addMoveZomby;
                        minion.m_iselemental = m_CurWave.isElementalzomby;
                        break;
                    } 
                }
                m_minions.Add(obj);
            }
        }
    }
}