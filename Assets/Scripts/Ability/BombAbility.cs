using System;
using System.Collections;
using UnityEngine;

public class BombAbility : BaseAbility
{
    [SerializeField] private GameObject m_explosionZone;
    [SerializeField] private float m_damage;
    [SerializeField] private SkinnedMeshRenderer m_renderer;
    [SerializeField] private GameObject m_zone;
    private BoxCollider m_collider;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Minion"))
        {
            m_renderer.enabled = false; 
            gameObject.GetComponent<BoxCollider>().enabled =  false;
            StartCoroutine(ExplosionCor());
        }
    }

    IEnumerator ExplosionCor()
    {
        m_explosionZone.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        m_zone.SetActive(false);
    }

    public float GetDamage()
    {
        return m_damage;
    }
        
}