using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

public class Enums : MonoBehaviour
{
}

public enum ElementType : byte
{
    None = 0,
    Fire = 1,
    Ice = 2,
    Poison = 3,
}

public enum MinionType : byte
{
    None = 0,
    Zomby = 1,
    Spider = 2,
    Orc = 3,
}

}