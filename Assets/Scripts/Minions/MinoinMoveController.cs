using System.Collections.Generic;
using TowerDefense;
using UnityEngine;
using UnityEngine.AI;

public class MinoinMoveController : MonoBehaviour
{
    [SerializeField] public List<Transform> m_points = new List<Transform>(); 
    private BaseMinion data;
    [SerializeField] private Transform target;
    private int indx;
    private NavMeshAgent m_agent;

    private void Start()
    {
        data = GetComponent<BaseMinion>();
        m_agent = GetComponent<NavMeshAgent>();
        indx = 0;
        target = m_points[indx];
        m_agent.SetDestination(target.position);
    }


    private void FixedUpdate()
    {
        if (m_agent.remainingDistance <= m_agent.stoppingDistance)
        {
            SetTarget();
            m_agent.SetDestination(target.position);
        }
    }

    public void SetRunIndex(int inx)
    {
        indx = -1;
    }

    //выбор новой точки для следования
    public void SetTarget()
    {
        indx++;
        if (indx > m_points.Count - 1)
        {
            return;
        }

        target = m_points[indx];
    }
}