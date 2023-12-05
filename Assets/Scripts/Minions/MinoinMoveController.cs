using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefense
{
    public class MinoinMoveController : MonoBehaviour
    {
        public Transform[] m_points = new Transform[]{};
        private BaseMinion data;
        [SerializeField] private Transform target;
        private int indx;
        private NavMeshAgent m_agent;


        private void Awake()
        {
            data = GetComponent<BaseMinion>();
            m_agent = GetComponent<NavMeshAgent>();
           
        }

        private void Start()
        {
            indx = 0;
            target = m_points[indx];
            m_agent.SetDestination(target.position);
        }

        private void LateUpdate()
        {
            if (m_agent.remainingDistance < m_agent.stoppingDistance)
            {
                SetTarget();
                m_agent.SetDestination(target.position);
            }
        }

        //выбор новой точки для следования
        private void SetTarget()
        {
            indx++;

            if (indx > m_points.Length - 1)
            {
                return;
            }

            target = m_points[indx];
        }
    }
}