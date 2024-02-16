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

        public void AfterBuild()
        {
            SphereCollider sphereCollider = GetComponentInChildren<SphereCollider>();
            sphereCollider.enabled = true;
            Destroy(this);
        }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Path" ||  other.gameObject.tag == "Tower")
        {
            m_buildComponent.SetMayBuild(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Path" ||  other.gameObject.tag == "Tower")
        {
                m_buildComponent.SetMayBuild(true);
                
        }

    }
    }
}