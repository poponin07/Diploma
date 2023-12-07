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
            Debug.Log(1);
            Destroy(other.gameObject);
        }
        
    }
}