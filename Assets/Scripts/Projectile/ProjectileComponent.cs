using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

public class ProjectileComponent : MonoBehaviour
{
   [SerializeField] private float m_speed;
   [SerializeField] private ElementType m_type;
   [SerializeField] private float m_damage;
    
   public Transform m_target;

   private void FixedUpdate()
    {
        Move();
    }

    public void SetDamage(float damage)
    {
        m_damage = damage;
    }
    
    private void Move()
    {
        if (m_target == null || !m_target.gameObject.activeSelf)
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
            BaseMinion minion = other.GetComponent<BaseMinion>();
            minion.GetDamage(m_damage, m_type);
            
            Destroy(gameObject);
        }
    }
}
}