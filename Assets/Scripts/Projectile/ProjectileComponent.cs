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
        //transform.position += Vector3.forward * m_speed * Time.deltaTime;
        gameObject.transform.Translate(Vector3.forward* m_speed * Time.deltaTime);
    }

    public void SetTarget(Transform miniom)
    {
        m_target = miniom;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Minion")
        {
            Destroy(gameObject);
            Debug.Log("Popal");
        }
    }
}
}