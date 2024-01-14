using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

namespace TowerDefense
{
public class PoolComponent : MonoBehaviour
{
[SerializeField]private Transform m_poolPosition;
[SerializeField] private GameObject m_zombi;

[SerializeField] private List<MinionComponent> m_AllMinions;
[SerializeField] private List<MinionComponent> m_ZombiMinions;
private Transform m_spaunPoint;

public GameObject SetMinion(GameObject minion, Transform point)
{
    m_spaunPoint = point;
 var min = GetFreeMinion(minion);
 return min;
}

public void DisableMinion(MinionComponent minion)
{
minion.gameObject.SetActive(false);
minion.transform.position = m_poolPosition.position;
}

public GameObject AddMinion(GameObject minion)
{
var min = Instantiate(minion, m_spaunPoint);
m_AllMinions.Add(minion.GetComponent<MinionComponent>());

return min;
}

public GameObject GetFreeMinion(GameObject minion)
{
MinionComponent minionComponent = minion.GetComponent<MinionComponent>();

foreach(var obj in m_AllMinions) 
{
    /*if(!obj.gameObject.activeSelf){
        
        obj.gameObject.SetActive(true);
        obj.transform.position = m_spaunPoint.position;

        return obj.gameObject;
    }*/
}
return AddMinion(minion);
}
}
}