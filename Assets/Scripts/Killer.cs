using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Killer : MonoBehaviour
    {
        [SerializeField] private PoolComponent m_poolComponent;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Minion")
            {
                BaseMinion minion = other.gameObject.GetComponent<BaseMinion>();
                m_poolComponent.Push(minion); 
            }
            
        }
        
    }
}