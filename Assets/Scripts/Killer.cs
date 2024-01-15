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
            BaseMinion minion = other.GetComponent<BaseMinion>();
         m_poolComponent.DisableMinion(minion);
        }
        
    }
}