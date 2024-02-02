using System;
using System.Collections.Generic;
using TowerDefense;
using UnityEngine;

public class PoolComponent : MonoBehaviour
{
    [SerializeField] private Transform m_poolPosition;
    [SerializeField] private Transform m_spawnPoint;
    [SerializeField] private List<BaseMinion> m_AllMinions;
    [SerializeField] private GameObject m_zombiPrefab;
    [SerializeField] private GameObject m_spiderPrefab;
    
    [SerializeField] private List<BaseMinion> m_dictionaryZombi = new List<BaseMinion>();
    [SerializeField] private List<BaseMinion> m_dictionarySpider = new List<BaseMinion>();
  

    private void Start()
    {
        //FillingPool();
    }
    
    public BaseMinion Pull(BaseMinion minion)
    {
        List<BaseMinion> minions = DeterminationMinionType(minion);

        foreach (var poolMinion in minions)
        {
            BaseMinion baseMinion = poolMinion;
            
            if (minions.Count > 0 && !baseMinion.gameObject.activeSelf)
            {
                m_AllMinions.Add(baseMinion);
                baseMinion.gameObject.transform.position = m_spawnPoint.position;
                baseMinion.gameObject.SetActive(true);
                
                return baseMinion;
            }
        }
        
        var newMinion = Instantiate(minion, m_spawnPoint.position, Quaternion.identity);
        BaseMinion newBaseMinion = newMinion.GetComponent<BaseMinion>();

        if (minion.Type == MinionType.Zomby)
        {
            m_dictionaryZombi.Add(newBaseMinion);
        }
        if (newMinion.Type == MinionType.Spider)
        {
            m_dictionarySpider.Add(newBaseMinion);
        }
        
        m_AllMinions.Add(minion.GetComponent<BaseMinion>());
        
        return newBaseMinion;
    }

    public void Push(BaseMinion minion)
    {
        List<BaseMinion> minions = DeterminationMinionType(minion);

        foreach (var pair in minions)
        {
            if (pair == minion)
            {
                minion.gameObject.transform.position = m_poolPosition.position;
                m_AllMinions.Remove(minion);
                minion.gameObject.SetActive(false);
            }
        }
    }

    private  List<BaseMinion>  DeterminationMinionType(BaseMinion minion)
    {
        MinionType type = minion.Type;
       List<BaseMinion> minions = new List<BaseMinion>();

        if (type == MinionType.Zomby)
        {
            minions = m_dictionaryZombi;
        }

        if (type == MinionType.Spider)
        {
            minions = m_dictionarySpider;
        }

        return minions;
    }

    private void FillingPool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject zombi = Instantiate(m_zombiPrefab, m_poolPosition.position, Quaternion.identity);
            zombi.SetActive(false);
            BaseMinion baseMinion = zombi.GetComponent<BaseMinion>();
            m_dictionaryZombi.Add(baseMinion);
        }
        
        for (int i = 0; i < 10; i++)
        {
            GameObject spider = Instantiate(m_spiderPrefab, m_poolPosition.position, Quaternion.identity);
            spider.SetActive(false);
            BaseMinion baseMinion = spider.GetComponent<BaseMinion>();
            m_dictionarySpider.Add(baseMinion);
        }
        
    }
        
    
}