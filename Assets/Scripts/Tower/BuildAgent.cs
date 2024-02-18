using System;
using UnityEngine;

namespace TowerDefense
{
    public class BuildAgent : MonoBehaviour
    { 
        private BuildComponent m_buildComponent;
        [SerializeField] private MeshRenderer m_renderer;

        [SerializeField] private Material m_green;
        [SerializeField] private Material m_red;
        [SerializeField] private Material m_default;

        private void Start()
        {
            m_renderer = GetComponent<MeshRenderer>();
        }

        public void Initialization(BuildComponent buildComponent)
        {
            m_buildComponent = buildComponent;
        }

        public void AfterBuild()
        {
            SphereCollider sphereCollider = GetComponentInChildren<SphereCollider>();
            sphereCollider.enabled = true;
            m_renderer.material = m_default;
            Destroy(this);
        }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Path" ||  other.gameObject.tag == "Tower")
        {
            m_buildComponent.SetMayBuild(false);
            m_renderer.material = m_red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Path" ||  other.gameObject.tag == "Tower")
        {
                m_buildComponent.SetMayBuild(true);
                m_renderer.material = m_green;
        }

    }
    }
}