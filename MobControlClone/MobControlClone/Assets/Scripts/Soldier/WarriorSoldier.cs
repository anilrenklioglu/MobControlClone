using Interfaces;
using UnityEngine;
using Utilities;

namespace Soldier
{
    public class WarriorSoldier : SoldierBase,IDamageable<int>,IKillable,IAttacker<int>
    {
        [SerializeField] private int _health = 2;
        private int _damagePower = 1;
        
        
        public int Health { get=>_health; set => _health = value;}
        public int DamagePower { get=> _damagePower; set=> _damagePower = value;}
        
        private ObjectPool _objectPool;

        private void Awake()
        {
            _objectPool = FindObjectOfType<ObjectPool>();
            
            targetBuilding = GameObject.FindGameObjectWithTag("Castle").transform;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Castle"))
            {
                _objectPool.ReturnToPool(0,gameObject);
                
               Attack(other.gameObject,DamagePower);
               
            }
            
            else if (other.CompareTag("Enemy_Goblin"))
            {
               Attack(other.gameObject,DamagePower);
               
               Die();
            }
        }
        
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
        
        public void Die()
        {
            if (_health <=0)
            {
                _objectPool.ReturnToPool(0,gameObject);
            }
        }
        public void Attack(GameObject target, int damage)
        {
            IDamageable<int> damageable = target.GetComponent<IDamageable<int>>();
            
            damageable?.TakeDamage(damage);
        }
    }
}