using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
public class ShootComponent : MonoBehaviour
{
   [SerializeField] private bool m_CanShoot;
    [SerializeField] private float m_Cooldown;
    [SerializeField] private float m_CurCooldown;
   [SerializeField]  private GameObject m_Target;
    private GameObject m_ProjectilePrefab;
   [SerializeField]  private float m_range;
    [SerializeField] private List<GameObject> m_Targets;
   [SerializeField] SphereCollider m_sphereCollider;


private void Start() 
{
    m_sphereCollider.radius = m_range;
}

private void FixedUpdate() 
{
    if(!m_Target) 
    {
        m_Target = SetTarget();
    }

    if(m_CurCooldown > 0)
    {
    m_CurCooldown -= Time.deltaTime;
    return;
    }
    Shoot();
}
    private GameObject SetTarget()
    {
        float minDistance = float.MaxValue;
        GameObject target = null;

        foreach(var minion in m_Targets) 
        {
            float dist = Vector3.Distance(transform.position, minion.transform.position);
            if(dist <= minDistance) 
            {
                minDistance = dist;
                target = minion;
            }  
        }
        return target;
    }

    private void DisableTarget()
    {

    }

    private void isCanShoot()
    {

    }

    private void Shoot()
    {

        if (m_Target)
        {
            Debug.Log("Shoot");
            m_CurCooldown = m_Cooldown;
            m_CanShoot = false; 
        }
       

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Minion") 
        {
            m_Targets.Add(other.gameObject);
        }
    }

    private void  OnTriggerExit(Collider other) 
    {
        if(other.tag == "Minion") 
        {
            m_Targets.Remove(other.gameObject);
        }
    }
    
}
}