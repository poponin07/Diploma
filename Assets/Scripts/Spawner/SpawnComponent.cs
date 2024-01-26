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
       [SerializeField]private Transform m_spawnPointTransform;
       private float m_spawnOffset;
       [SerializeField] private GameObject m_zombPrefab;
       [SerializeField] private Transform path;
       [SerializeField] private List<Transform> m_path;
       [SerializeField] private PoolComponent m_poolComponent;
       
       private int m_ZombiGainCount = 3;
       private int m_CurZombiCount;
       private int m_SpiderGainCount = 1;
       private int m_CurSpiderCount;
       
       private Coroutine spawnCor;
       
        private void Start()
        {
            var myArray= path.GetComponentsInChildren<Transform>();
            m_path = myArray.ToList();
            m_path.Remove(m_path[0]);

            //m_poolComponent = GetComponent<PoolComponent>();

            m_spawnOffset = 1f;
            
        }
        
        public void StartSwawn(List<GameObject> minions)
        {
            int indxZomby = m_ZombiGainCount + m_CurZombiCount;
            int indxSpider = m_SpiderGainCount + m_CurSpiderCount;
            

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
             
             
             SpawnMinion(spawnList);
        }
        
        private void SpawnMinion(List<GameObject> spawnList)
        {
            
            int minInd = 0;
            foreach (var obj in spawnList)
            {
                GameObject min = m_poolComponent.SetMinion(obj, m_spawnPointTransform);
                MinoinMoveController RemovedComponent = min.GetComponent<MinoinMoveController>();
                RemovedComponent.SetTarget();
                RemovedComponent.SetRunIndex(-1);
                RemovedComponent.m_points = m_path;
                StartCoroutine(SpawnOffset());
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
                
            }
          
        }

        IEnumerator SpawnOffset()
        {

            while (true)
            {
                yield return new WaitForSeconds(m_spawnOffset);
                break;
            }
        }
        
        
    }
    public class Wave : MonoBehaviour
    {
        public BaseMinion[] minions;
    }
}