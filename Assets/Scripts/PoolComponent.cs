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
[SerializeField] private List<BaseMinion> m_SpiderMinions;
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
    //m_ZombiMinions.Add(minion);
    EnableTypeMinion(true, minion.Type, minion);
    
    minion.gameObject.SetActive(false);
    minion.transform.position = m_poolPosition.position;
}

public GameObject AddMinion(GameObject minion)
{
var min = Instantiate(minion, m_spaunPoint.position, Quaternion.identity);
var baceMin = min.GetComponent<BaseMinion>();

//EnableTypeMinion(true, baceMin.Type, baceMin);

m_AllMinions.Add(minion.GetComponent<BaseMinion>());
return min;
}

public GameObject GetFreeMinion(GameObject minion)
{
    var minionComponent = minion.GetComponent<BaseMinion>().Type;
    List<BaseMinion> listPool = new List<BaseMinion>();
    
    if (minionComponent == MinionType.Zomby)
        listPool = m_ZombiMinions;
    if (minionComponent == MinionType.Spider)
        listPool = m_SpiderMinions;
    
        foreach(var obj in listPool) 
        {
    if(listPool.Count > 0 && !obj.gameObject.activeSelf)
    {
        EnableTypeMinion(false, minionComponent, obj);
        m_AllMinions.Add(obj);
        obj.gameObject.SetActive(true);
        return obj.gameObject;
    }
}
return AddMinion(minion);
}

private void EnableTypeMinion(bool isAdd, MinionType type, BaseMinion minion)
{
    if (isAdd)
    {
        if (type == MinionType.Zomby)
        {
            m_ZombiMinions.Add(minion); 
        }

        if (type == MinionType.Spider)
        {
            m_SpiderMinions.Add(minion); 
        }
    }
    else
    {
        if (type == MinionType.Zomby)
        {
            m_ZombiMinions.Remove(minion); 
        }

        if (type == MinionType.Spider)
        {
            m_SpiderMinions.Remove(minion); 
        }
    }
    
}

}
}