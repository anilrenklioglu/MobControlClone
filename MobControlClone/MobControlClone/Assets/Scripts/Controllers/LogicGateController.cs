using System;
using System.Collections.Generic;
using Enums;
using Soldier;
using UnityEngine;
using Utilities;

namespace Controllers
{
    public class LogicGateController : MonoBehaviour
    {
        public LogicGateType gateType;
        public int gateNumber;
        
        [SerializeField] private Transform spawnPos;
       
        private ObjectPool _objectPool;
        private void Awake()
        {
            _objectPool = FindObjectOfType<ObjectPool>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Soldier_Warrior") && !other.GetComponent<WarriorSoldier>().isBoss)
            {
                CalculateProcess(other.gameObject);
            }
        }
        private void CalculateProcess(GameObject other)
        {
            List<GameObject> collidedSoldiers = new List<GameObject>();
            
            if (!collidedSoldiers.Contains(other))
            {
                collidedSoldiers.Add(other);
                
                switch (gateType)
                {
                   
                    case LogicGateType.Add:
                    
                        for (int i = 0; i < gateNumber; i++)
                        {
                            GameObject obj =  _objectPool.GetPooledObject(0);
                       
                            obj.transform.position = spawnPos.position;
                        }
                    
                        break;
                    case LogicGateType.Multiply:
                    
                        for (int i = 0; i < gateNumber; i++)
                        {
                            GameObject obj =  _objectPool.GetPooledObject(0);
                       
                            obj.transform.position = spawnPos.position;
                        }
                        break;
                }
            }
          
        }
    }
}