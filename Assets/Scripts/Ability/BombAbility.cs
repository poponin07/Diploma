using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class BombAbility : MonoBehaviour
{
    [SerializeField] private GameObject m_explosionZone;
    [SerializeField] private float m_damage;
    [SerializeField] private SkinnedMeshRenderer m_renderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Minion"))
        {
            m_renderer.enabled = false;
            StartCoroutine(ExplosionCor());
        }
    }

    IEnumerator ExplosionCor()
    {
        m_explosionZone.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return m_damage;
    }
        
}