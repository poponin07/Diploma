using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerDefense
{
    public class BobScript : MonoBehaviour
    {
        [SerializeField] private BombAbility m_bombAbility;
        [SerializeField] protected TextMeshProUGUI m_coolDownText;
        [SerializeField] private GameObject m_root;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Minion"))
            {
                BaseMinion minion = other.GetComponent<BaseMinion>();
                minion.GetDamage(m_bombAbility.GetDamage(), ElementType.None);
            }
        }
        
    }
}