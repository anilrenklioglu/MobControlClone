using Interfaces;
using Managers;
using UnityEngine;

namespace Buildings
{
    public class BuildingController : MonoBehaviour,IDamageable<int>
    {
        private int _health = 50;
        public int Health {get =>_health; set => _health = value; }
        public void TakeDamage(int damage)
        {
            Health -= damage;

          //  CurrencyManager.Instance.AddGold(GameManager.Instance.buildingDamageReward);
          
        }
    }
}
