using System.Collections.Generic;
using Minions;
using TowerDefense;
using UnityEngine;
using UnityEngine.InputSystem.HID;

namespace Waves
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
        [SerializeField] private UIManager m_UIManager;
        [SerializeField] private PlayerData m_playerData;


        private void Start()
        {
            m_CurWave = m_waveGrs[m_CurWaveIndex];
            ConfigurationMinions();
        }

        private void Update()
        {
           
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

        public void MinionSpawn(BaseMinion minion)
        {
            m_AllMinions.Add(minion);
        }
        
        public void MinionDespawn(BaseMinion minion)
        {
            m_AllMinions.Remove(minion);
            
            if (m_AllMinions.Count <= 0)
            {
                m_UIManager.EnableNextWaveButton();
            }
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
                    baseMinion.Damage = m_CurWave.damageZombie;
                    baseMinion.Health = m_CurWave.healthZombie;
                    baseMinion.Speed = m_CurWave.moveZombie;
                    baseMinion.Score = m_CurWave.ScoreZombie;
                    baseMinion.m_isElemental = m_CurWave.isElementalZombie;
                    break;
                }

                case SpiderComponent:
                {
                    baseMinion.Damage = m_CurWave.damageSpider;
                    baseMinion.Health = m_CurWave.healthSpider;
                    baseMinion.Speed = m_CurWave.moveSpider;
                    baseMinion.Score = m_CurWave.ScoreSpider;
                    baseMinion.m_isElemental = m_CurWave.isElementalSpider;
                    break;
                }
            }

            return baseMinion;
        }
    }
}