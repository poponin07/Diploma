using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoinMoveController : MonoBehaviour
{
    private float speed;
    [SerializeField] private List<GameObject> points = new List<GameObject>();
    private GameObject target;
    private int indx;

    private void Start()
    {
        indx = 0;
        target = points[indx];
        speed = 3f;
    }

    private void FixedUpdate()
    {
        if (indx == points.Count)
        {
            return;
        }
        target = points[indx];
        if (Vector3.Distance(transform.position, target.transform.position) >= 0.5f)
        {
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
        else
        {
            indx++;
            
        }
    }
}