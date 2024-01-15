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
        public List<Transform> m_points;
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

        private void FixedUpdate()
        {
            if (m_agent.remainingDistance < m_agent.stoppingDistance)
            {
                SetTarget(false);
                m_agent.SetDestination(target.position);
            }
        }

        //выбор новой точки для следования
        public void SetTarget(bool startPoint)
        {
            if (startPoint)
            {
                target = m_points[0];
                indx = 0;
                return;
            }

            if (indx > m_points.Count - 1)
            {
                return;
            }
            
            indx++;
            target = m_points[indx];
        }
    }
}