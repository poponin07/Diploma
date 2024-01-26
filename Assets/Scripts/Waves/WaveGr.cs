using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(fileName = "NewWave", menuName = "Wave/Create wave")]
    public class WaveGr : ScriptableObject
    {
        [Header("Minions")] 
        public List<GameObject> minioms = new List<GameObject>();

        [Header("Grade zomby")] 
        public bool isElementalzomby;
        public float addHealthZomby;
        public float addMoveZomby;
        public float addDamageZomby;
        
        [Header("Grade spider")] 
        public bool isElementalSpider;
        public float addHealth;
        public float moveSpider;
        public float addDamageSpider;
    }
}