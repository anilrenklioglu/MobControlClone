using System;
using Interfaces;
using Managers;
using UnityEngine;
using Utilities;

namespace Enemies
{
    public class GoblinEnemy : EnemyBase, IDamageable<int>,IKillable,IAttacker<int>
    {
        private int _health = 1;
        private int _damagePower = 1;
      
        public int Health { get=>_health; set => _health = value;}
        public int DamagePower { get => _damagePower; set => _damagePower = value;}
       

        private ObjectPool _objectPool;

        private void Awake()
        {
            _objectPool = FindObjectOfType<ObjectPool>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Soldier_Warrior"))
            {
                Attack(other.gameObject, DamagePower);
                
                Die();
            }
            
            else if (other.CompareTag("Cannon"))
            {
                _objectPool.ReturnToPool(1,gameObject);
            }
        }
        
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
        
        public void Die()
        {
            if (_health <= 1)
            {
                _objectPool.ReturnToPool(1,gameObject);
                
                CurrencyManager.Instance.AddGold(GameManager.Instance.enemyDeathReward);
            }
        }

        public void Attack(GameObject target, int damage)
        {
            IDamageable<int> damageable = target.GetComponent<IDamageable<int>>();

            damageable?.TakeDamage(damage);
        }
    }
}