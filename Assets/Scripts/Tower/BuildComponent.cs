using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

namespace TowerDefense
{
    public class BuildComponent : MonoBehaviour
    {
        private InputController _input;
        private Ray ray;
        [SerializeField] private GameObject m_commonTower;
        [SerializeField] private GameObject m_fireTower;
        [SerializeField] private GameObject m_iceTower;
        [SerializeField] private GameObject m_posionTower;
        [SerializeField] private PlayerData m_playerData;
        private Plane plane = new Plane(Vector3.up, 0);
        public bool isBuild;

private void Awake()
        {
            _input = new InputController();
            _input.Enable();
            isBuild = true;
        }

        private void Start()
        {
            _input.Player.ClickForReycast.canceled += context =>  OnRayCastPlayer();
        }

        public void SetMayBuild(bool result)
        {
            isBuild = result;
        }
        
        public void CheckCanBuildTower(GameObject tower)
        {
            GameObject newTower = Instantiate(tower, new Vector3(55, 5, 5), Quaternion.identity);
            int towerPrice = newTower.GetComponent<TowerComponent>().Price;
            if (!m_playerData.CheckCoins(towerPrice))
            {
                Destroy(newTower); 
                return;
            }
            StartCoroutine(TowerMagnetToCursor(newTower));
        }

        private void OnRayCastPlayer()
        {
            Camera _camera = Camera.main;
            ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out var hit))
            {
               if (hit.collider.GetComponent<MinoinMoveController>())
                {
                    Debug.Log("Zomby");
                }
            }
        }

        IEnumerator TowerMagnetToCursor(GameObject tower)
        {
            Camera _camera = Camera.main;
            //GameObject towerB = Instantiate(tower, new Vector3(55, 5, 5), Quaternion.identity);
            BuildAgent buildAgent = tower.GetComponent<BuildAgent>();
            buildAgent.Initialization(this);
            
            while(true)
            {
                ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

                if (plane.Raycast(ray, out float distance))
                {
                    tower.transform.position = ray.GetPoint(distance);
                    ShootComponent shoot = tower.GetComponent<ShootComponent>();

                    if (Input.GetKeyDown(KeyCode.Mouse0) && isBuild)
                    {
                        buildAgent.enabled = false;
                        buildAgent.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                        buildAgent.AfterBuildTodtr();
                        shoot.enabled = true;
                        break;
                    }
                }
                
            yield return null;
            }
            
        }
    }
}