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

        private void Awake()
        {
            _input = new InputController();
            _input.Enable();
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