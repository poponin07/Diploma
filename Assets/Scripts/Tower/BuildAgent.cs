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

        public void AfterBuildTodtr()
        {
            SphereCollider sphereCollider = GetComponentInChildren<SphereCollider>();
            sphereCollider.enabled = true;
            Destroy(this);
        }

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