using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

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
    Debug.Log("Set");
 var min = GetFreeMinion(minion);
 return min;
}

public void DisableMinion(MinionComponent minion)
{
minion.gameObject.SetActive(false);
m_AllMinions.Remove(minion);
m_ZombiMinions.Add(minion);
minion.transform.position = m_poolPosition.position;
}

public GameObject AddMinion(GameObject minion)
{
var min = Instantiate(minion, m_spaunPoint.position, Quaternion.identity);
m_AllMinions.Add(minion.GetComponent<MinionComponent>());

return min;
}

public GameObject GetFreeMinion(GameObject minion)
{
MinionComponent minionComponent = minion.GetComponent<MinionComponent>();

foreach(var obj in m_ZombiMinions) 
{
    if(!obj.gameObject.activeInHierarchy)
    {
        m_AllMinions.Add(minionComponent);
        obj.transform.position = m_spaunPoint.position;
        obj.gameObject.SetActive(true);
        return obj.gameObject;
    }
}
return AddMinion(minion);
}
}
}