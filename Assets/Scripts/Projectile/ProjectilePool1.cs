using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class ProjectilePool1 : MonoBehaviour
    {
        public GameObject bulletPrefab; // Список префабов пуль
        [SerializeField] private int poolSize; // Размер пула пуль
        private List<GameObject> availableBullets = new List<GameObject>(); // Список доступных пуль

        void Start()
        {
            // Инициализируем пул пуль
            InitializeBulletPool();
        }

        void InitializeBulletPool()
        {
            // Создаем и активируем пули из префабов
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                bullet.SetActive(false); // Делаем пулю неактивной
                availableBullets.Add(bullet);
            }
        }

        public GameObject GetBullet()
        {
            // Ищем доступную пулю в пуле
            foreach (var bullet in availableBullets)
            {
                if (!bullet.activeInHierarchy)
                {
                    return bullet;
                }
            }

            return null; // Если все пули заняты, возвращаем null
        }

        public void ReturnBullet(GameObject bullet)
        {
            // Возвращаем пулю в пул после использования
            bullet.SetActive(false);
        }
    }
}