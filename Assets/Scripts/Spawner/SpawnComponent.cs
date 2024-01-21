﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        private int m_zombiGainCount = 3;
        private int m_CurZombiCount; 
        private void Start()
        {
            var myArray= path.GetComponentsInChildren<Transform>();
            m_path = myArray.ToList();
            m_path.Remove(m_path[0]);

            m_poolComponent = GetComponent<PoolComponent>();

            m_spawnOffset = 2f;
            
            StartCoroutine(SpawnCor());
        }

        IEnumerator SpawnCor()
        {
            while (true)
            {
                yield return new WaitForSeconds(m_spawnOffset);
                GameObject min = m_poolComponent.SetMinion(m_zombPrefab, m_spawnPointTransform);
                MinoinMoveController RemovedComponent = min.GetComponent<MinoinMoveController>();
                RemovedComponent.SetTarget();
                RemovedComponent.SetRunIndex(-1);
                RemovedComponent.m_points = m_path;
            }
        }
        
    }
    public class Wave : MonoBehaviour
    {
        public BaseMinion[] minions;
    }
}