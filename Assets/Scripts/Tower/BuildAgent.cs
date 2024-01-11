using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class BuildAgent : MonoBehaviour
    { 
        private BuildComponent m_buildComponent;

        public void Initialization(BuildComponent buildComponent)
        {
            m_buildComponent = buildComponent;
        }
    private void OnCollisionStay(Collision other)
    {
       
    }

   /* private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Path")
        {
            m_buildComponent.SetMayBuild(false);
            Debug.Log("path");
        }
        else
        {
            m_buildComponent.SetMayBuild(true);
            Debug.Log("NOpath");
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Path")
        {
            m_buildComponent.SetMayBuild(false);
            Debug.Log("path");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Path")
        {
                m_buildComponent.SetMayBuild(true);
                
                Debug.Log("path");
        }

    }
    }
}