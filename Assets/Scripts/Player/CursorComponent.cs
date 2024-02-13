using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TowerDefense
{
    public class CursorComponent : MonoBehaviour
    {
        [SerializeField] private UpgradeScript m_upgradeScript;
        private InputController _input;
        private Ray ray;
        private const string Tower_Tag = "Tower";

        private TowerComponent m_towerComponent = null;
        private UpgradeTowerComponent m_upgradeTowerComponent;

        private int m_layerTowerNumber = 6;
        private int m_layerUINumber = 5;
        private int m_layerTowerMask;
        private int m_layerUIMask;
        
        
        private void Awake()
        {
            _input = new InputController();
            _input.Enable();
        }
        
        private void Start()
        {
            _input.Player.ClickForReycast.canceled += context =>  OnRayCastTower();
            m_layerTowerMask = 1 << m_layerTowerNumber;
            m_layerUIMask = 1 << m_layerUINumber;
        }

        private void OnRayCastTower()
        {
            Camera _camera = Camera.main;
            ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity,m_layerTowerMask))
            {
                if (hit.collider.gameObject.tag.Equals(Tower_Tag))
                {
                    TowerComponent component = hit.collider.gameObject.GetComponent<TowerComponent>();

                    if (component != m_towerComponent)
                    {
                        m_towerComponent = component;
                        m_upgradeScript.m_selectedUpgrade = m_towerComponent.upgradeTowerComponent;
                        hit.collider.gameObject.GetComponent<TowerComponent>().uiUpgradeWindow.Show();
                    }
                }
            }
            else if(m_towerComponent != null)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                m_towerComponent.GetComponent<TowerComponent>().uiUpgradeWindow.Hide();
                m_towerComponent = null;
            }

            

        }
    }
}