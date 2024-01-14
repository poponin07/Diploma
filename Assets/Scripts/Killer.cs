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
            MinionComponent minion = other.GetComponent<MinionComponent>();
         m_poolComponent.DisableMinion(minion);
        }
        
    }
}