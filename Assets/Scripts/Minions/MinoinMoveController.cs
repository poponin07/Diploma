using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class MinoinMoveController : MonoBehaviour
{
    [SerializeField] private List<Transform> m_points = new List<Transform>(); 
    private BaseMinion data;
    private Transform target;
    private int indx;


    private void Start()
    {
        data = GetComponent<BaseMinion>();
        indx = 0;
        target = m_points[indx];
    }

    private void FixedUpdate()
    {
        
    }

    //выбор новой точки для следования
    private void SetTarget()
    {
        indx++;
        if (indx > m_points.Count - 1)
        {
            return;
        }

        target = m_points[indx];
    }
}