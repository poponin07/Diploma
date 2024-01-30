using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    interface IGetDamage
    {
       void GetDamage(float damage);
       void OnDie();
    }
}