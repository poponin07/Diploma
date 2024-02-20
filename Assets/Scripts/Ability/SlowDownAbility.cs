using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowDownAbility : BaseAbility
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Minion"))
        {
           var miniomspeed =  other.gameObject.GetComponent<NavMeshAgent>().speed;
           miniomspeed -= 2;
           Debug.Log("slow");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Minion"))
        {
            var miniomspeed =  other.gameObject.GetComponent<NavMeshAgent>().speed;
            miniomspeed += 2;
            Debug.Log("slow---");
        }
    }
}
