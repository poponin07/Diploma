using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowDownAbility : BaseAbility
{
    [SerializeField] private float m_slowAmount;
    [SerializeField] private float m_lifeTime;
    public bool isBuild;

    private void FixedUpdate()
    {
        if (isBuild)
        {
            m_lifeTime -= Time.deltaTime;
            if (m_lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Minion"))
        {
           other.gameObject.GetComponent<NavMeshAgent>().speed -= m_slowAmount;
           isBuild = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Minion"))
        {
          other.gameObject.GetComponent<NavMeshAgent>().speed += m_slowAmount;
        }
    }
}
