using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;

namespace TowerDefense
{
public class PoolComponent : MonoBehaviour
{
[SerializeField]private Transform m_poolPosition;
[SerializeField] private GameObject m_zombi;

[SerializeField] private List<BaseMinion> m_AllMinions;
[SerializeField] private List<BaseMinion> m_ZombiMinions;
private Transform m_spaunPoint;

public GameObject SetMinion(GameObject minion, Transform point)
{
m_spaunPoint = point.transform;
 var min = GetFreeMinion(minion);
 return min;
}

public void DisableMinion(BaseMinion minion)
{
    m_AllMinions.Remove(minion);
    m_ZombiMinions.Add(minion);
    minion.gameObject.SetActive(false);
    minion.transform.position = m_poolPosition.position;
}

public GameObject AddMinion(GameObject minion)
{
var min = Instantiate(minion, m_spaunPoint.position, Quaternion.identity); 
m_AllMinions.Add(minion.GetComponent<BaseMinion>());
return min;
}

public GameObject GetFreeMinion(GameObject minion)
{
BaseMinion minionComponent = minion.GetComponent<BaseMinion>();

foreach(var obj in m_ZombiMinions) 
{
    if(!obj.gameObject.activeSelf){
        
        m_ZombiMinions.Remove(obj);
        m_AllMinions.Add(obj);
        obj.gameObject.SetActive(true);

        return obj.gameObject;
    }
}
return AddMinion(minion);
}
}
}