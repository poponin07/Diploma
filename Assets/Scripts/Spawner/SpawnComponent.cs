using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace TowerDefense
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform m_spawnPointTransform;
        private float m_spawnOffset;
        [SerializeField] private Transform path;
        [SerializeField] private List<Transform> m_path;
        [SerializeField] private PoolComponent m_poolComponent;

        private int m_ZombiGainCount = 2;
        private int m_CurZombiCount;
        private int m_SpiderGainCount = 1;
        private int m_CurSpiderCount;

        private Coroutine spawnCor;
        private WaveManager m_waveManager;

        private void Start()
        {
            var myArray = path.GetComponentsInChildren<Transform>();
            m_path = myArray.ToList();
            m_path.Remove(m_path[0]);

            m_spawnOffset = 0.5f;

            m_waveManager = m_poolComponent.gameObject.GetComponent<WaveManager>();

        }

       [SerializeField] private List<GameObject> mini = new List<GameObject>();

        public void StartSwawn(List<GameObject> minions)
        {
            mini = minions;
            int indxZomby = m_ZombiGainCount + m_CurZombiCount;
            int indxSpider = m_SpiderGainCount + m_CurSpiderCount;

            m_CurZombiCount += m_ZombiGainCount;
            m_CurSpiderCount += m_SpiderGainCount;

            List<GameObject> spawnList = new List<GameObject>();

            foreach (var obj in minions)
            {

                switch (obj.GetComponent<BaseMinion>().Type)
                {
                    case MinionType.Zomby:
                        for (int i = 0; i < indxZomby; i++)
                        {
                            spawnList.Add(obj);
                        }

                        break;

                    case MinionType.Spider:
                        for (int i = 0; i < indxSpider; i++)
                        {
                            spawnList.Add(obj);
                        }

                        break;
                }
            }
            SpawnMinionCor(spawnList);
        }

        private void SpawnMinionCor(List<GameObject> spawnList)
        {
            StartCoroutine(SpawnOffset(spawnList));
        }

        private void SpawnMinion(GameObject obj)
        {
            int minInd = 0;
            GameObject min = m_poolComponent.SetMinion(obj, m_spawnPointTransform);
            min.GetComponent<BaseMinion>().Initialization(m_waveManager);
            MinoinMoveController moveComponent = min.GetComponent<MinoinMoveController>();
            moveComponent.SetTarget();
            moveComponent.SetRunIndex(-1);
            min.transform.position = m_spawnPointTransform.position;
            moveComponent.m_points = m_path;
            minInd++;

            switch (obj.GetComponent<BaseMinion>().Type)
            {
                case MinionType.Zomby:
                    if (minInd > (m_ZombiGainCount + m_CurZombiCount))
                    {
                        return;
                    }

                    break;

                case MinionType.Spider:
                    if (minInd > (m_SpiderGainCount + m_CurSpiderCount))
                    {
                        return;
                    }

                    break;
            }

            return; 
        }

        IEnumerator SpawnOffset(List<GameObject> spawnList)
        {
            foreach (var obj in spawnList)
            {
                yield return new WaitForSeconds(m_spawnOffset);
                SpawnMinion(obj);
            }
        }
    }
}