using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

private void Awake()
        {
            _input = new InputController();
            _input.Enable();
        }

        private void Start()
        {
            _input.Player.ClickForReycast.canceled += context =>  OnRayCastPlayer();
        }

        private void Update()
        {
            
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
            while(true)
            {
                GameObject towerB = Instantiate(tower_1, new Vector3(55, 5, 5), Quaternion.identity);
                towerB.transform.position = 
            yield return null;
            }
            
        }
    }
}