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
        public GameObject tower_1;
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

        public void StartBuild()
        {
            StartCoroutine(TowerMagnetToCursor());
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

        IEnumerator TowerMagnetToCursor()
        {
            Camera _camera = Camera.main;
            GameObject towerB = Instantiate(tower_1, new Vector3(55, 5, 5), Quaternion.identity);
            BuildAgent buildAgent = towerB.GetComponent<BuildAgent>();
            buildAgent.Initialization(this);
            
            while(true)
            {
                ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

                if (plane.Raycast(ray, out float distance))
                {
                    towerB.transform.position = ray.GetPoint(distance);

                    if (Input.GetKeyDown(KeyCode.Mouse0) && isBuild)
                    {
                        buildAgent.enabled = false;
                        buildAgent.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                        buildAgent.AfterBuildTodtr();
                        break;
                    }
                }
                
            yield return null;
            }
            
        }
    }
}