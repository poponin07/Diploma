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

        public bool infinityWave;

        [Header("Grade zomby")] 
        public bool isElementalZombie;
        public float healthZombie;
        public float moveZombie;
        public float damageZombie;
        public int ScoreZombie;
        
        [Header("Grade spider")] 
        public bool isElementalSpider;
        public float healthSpider;
        public float moveSpider;
        public float damageSpider;
        public int ScoreSpider;
        
        [Header("Grade orc")] 
        public bool isElementalOrc;
        public float healthOrc;
        public float moveOrc;
        public float damageOrc;
        public int ScoreOrc;
    }
}