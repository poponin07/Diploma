using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

public class ProjectileComponent : MonoBehaviour
{
   [SerializeField] private float m_speed;
    private float m_damage;
    public Transform m_target;

    private void Start()
    {
        m_damage = 10000;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (m_target == null)
        {
            Destroy(gameObject);
        }
        transform.LookAt(m_target);
        gameObject.transform.Translate(Vector3.forward* m_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Minion")
        {
            other.GetComponent<BaseMinion>().GetDamage(m_damage);
            Destroy(gameObject);
        }
    }
}
}