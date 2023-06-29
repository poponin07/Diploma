using System.Collections;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;
using UnityEngine.UIElements;

namespace TowerDefense
{
    public class WalkBehavior : StateMachineBehaviour
    {
        [SerializeField] private BaseMinion m_minion;
        [SerializeField] private List<GameObject> points;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_minion = animator.GetComponent<BaseMinion>();
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
           Debug.Log( m_minion.name);
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

    }
}