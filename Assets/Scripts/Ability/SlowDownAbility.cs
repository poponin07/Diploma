using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowDownAbility : BaseAbility
{
    [SerializeField] private float m_slowAmount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Minion"))
        {
           var miniomspeed =  other.gameObject.GetComponent<NavMeshAgent>().speed -= m_slowAmount;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Minion"))
        {
            var miniomspeed =  other.gameObject.GetComponent<NavMeshAgent>().speed += m_slowAmount;
        }
    }
}
