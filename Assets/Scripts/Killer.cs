using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Killer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Minion")
            {
                BaseMinion minion = other.gameObject.GetComponent<BaseMinion>();
                minion.Despawn(true);
            }
            
        }
        
    }
}