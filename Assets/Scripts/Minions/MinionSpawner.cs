using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
   [SerializeField] private Transform m_spawnPoint;
   [SerializeField] private List<Transform> m_spawnPoints;
   [SerializeField] private GameObject m_enemyPrifab;
   private float m_spawnBreak;

   private void Awake()
   {
      m_spawnBreak = 3f;
      //SpawnEnemy();
   }


   public void SpawnEnemy()
   {
      StartCoroutine(SpawnEnemyCoroutine());
   }

   IEnumerator SpawnEnemyCoroutine()
   {
      GameObject newEnemy = Instantiate(m_enemyPrifab, new Vector3(m_spawnPoint.position.x, m_spawnPoint.position.y, m_spawnPoint.position.z),Quaternion.identity );
      yield return new WaitForSeconds(m_spawnBreak);
      SpawnEnemy();
   }
   
}
