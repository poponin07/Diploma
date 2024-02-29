using System;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;
using UnityEngine.AI;

public class SlowDownAbility : BaseAbility
{
    [SerializeField] private float m_slowAmount;
    [SerializeField] private float m_lifeTime;
    private BoxCollider m_zoneCollider;
    private List<BaseMinion> _minions = new ();

    private bool isSet;

    private void Start()
    {
        m_zoneCollider = gameObject.GetComponent<BoxCollider>();
    }
    
    protected override void isBuild()
    {
        m_zoneCollider.enabled = true;
        isSet = true;

    }

    private void FixedUpdate()
    {
        if (isSet)
        {
            m_lifeTime -= Time.deltaTime;
            
            if (m_lifeTime <= 0)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                DisableZone();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Minion"))
        {
           other.gameObject.GetComponent<NavMeshAgent>().speed -= m_slowAmount;
           _minions.Add(other.gameObject.GetComponent<BaseMinion>());
           isSet = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Minion"))
        {
          other.gameObject.GetComponent<NavMeshAgent>().speed += m_slowAmount;
          _minions.Remove(other.gameObject.GetComponent<BaseMinion>());
        }
    }

    private void DisableZone()
    {
        foreach (var minion in _minions)
        {
            minion.SetSpeed(minion.Speed);
        }
    }

}
