using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class SpawnComponent : MonoBehaviour
    {
       [SerializeField]private Transform m_spawnPointTransform;
        private float m_spawnOffset;
        [SerializeField] private GameObject m_zombPrefab;
        [SerializeField] private Transform path;
       [SerializeField] private Transform[] m_path;
       [SerializeField] private PoolComponent m_poolComponent;

        private void Start()
        {
            m_path = path.GetComponentsInChildren<Transform>();
            m_poolComponent = GetComponent<PoolComponent>();
            m_spawnOffset = 2f;
            StartCoroutine(SpawnCor());
        }

        IEnumerator SpawnCor()
        {
            while (true)
            {
                 yield return new WaitForSeconds(m_spawnOffset);
                //var min = Instantiate(m_zombPrefab, m_spawnPointTransform);
                var min = m_poolComponent.SetMinion(m_zombPrefab ,m_spawnPointTransform);
                min.GetComponent<MinoinMoveController>().m_points = m_path;
            }
        }
        
    }
}