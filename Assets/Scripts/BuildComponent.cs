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

        private void Awake()
        {
            _input = new InputController();
            Debug.Log("Click");
        }

        private void Start()
        {
            _input.Player.ClickForReycast.canceled += context =>  OnRayCastPlayer();
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

    }
}