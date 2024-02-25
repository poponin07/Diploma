using UnityEngine;

namespace TowerDefense
{
    public class BobScript : MonoBehaviour
    {
        [SerializeField] private BombAbility m_bombAbility;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Minion"))
            {
                BaseMinion minion = other.GetComponent<BaseMinion>();
                minion.GetDamage(m_bombAbility.GetDamage(), ElementType.None);
            }
        }
    }
}