using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using TowerDefense;
using UnityEngine;

public class MinionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_curHealthText;
    private float m_health;
    public Camera camera;
    public GameObject root;


    private void FixedUpdate()
    {
        root.transform.LookAt(camera.transform);
    }

    public void SetHealth(float health, ElementType type)
    {
        switch (type)
        {
            case ElementType.None:
                m_curHealthText.color = Color.white;
                break;
            
            case ElementType.Fire:
                m_curHealthText.color = Color.red;
                break;
            
            case ElementType.Ice:
                m_curHealthText.color = Color.blue;
                break;
            
            case ElementType.Poison:
                m_curHealthText.color = Color.green;
                break;
        }
        m_curHealthText.text = health.ToString();
    }

    public void RefreshHealth(float health)
    {
       /* m_health  = - damage;
        if (m_health <= 0)
        {
            m_health = 0;
        }*/
       m_health = health;
        m_curHealthText.text = m_health.ToString(CultureInfo.InvariantCulture);
    }
}
