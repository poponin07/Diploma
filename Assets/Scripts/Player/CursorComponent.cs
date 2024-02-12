using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TowerDefense
{
    public class CursorComponent : MonoBehaviour
    {
        private InputController _input;
        private Ray ray;
        private const string Tower_Tag = "Tower";

        private TowerComponent m_towerComponent = null;
        private UpgradeTowerComponent m_upgradeTowerComponent;

        private int m_layerNumber = 6;
        private int m_layerMask;

        private void Awake()
        {
            _input = new InputController();
            _input.Enable();
        }
        
        private void Start()
        {
            _input.Player.ClickForReycast.canceled += context =>  OnRayCastTower();
            m_layerMask = 1 << m_layerNumber;
        }

        private void OnRayCastTower()
        {
            Camera _camera = Camera.main;
            ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity,m_layerMask))
            {
                if (hit.collider.gameObject.tag.Equals(Tower_Tag))
                {
                    TowerComponent component = hit.collider.gameObject.GetComponent<TowerComponent>();
                    
                    //m_upgradeTowerComponent = hit.collider.gameObject.GetComponent<UpgradeTowerComponent>();
                   // m_upgradeTowerComponent.upgradeTowerComponent.Show();
                    
                    if (component != m_towerComponent)
                    {
                        m_towerComponent = component;
                        hit.collider.gameObject.GetComponent<TowerComponent>().upgradeWindow.Show();
                        //m_upgradeTowerComponent.upgradeTowerComponent.Show();
                    }
                    
                }
            }
            else if(m_towerComponent != null)
            {
                m_towerComponent.GetComponent<TowerComponent>().upgradeWindow.Hide();
                m_towerComponent = null;
            }

            

        }
    }
}