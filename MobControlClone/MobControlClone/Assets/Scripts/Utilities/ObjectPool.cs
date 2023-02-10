using System;
using System.Collections.Generic;
using UnityEngine;


namespace Utilities
{
    public class ObjectPool : MonoBehaviour
    {
        [Serializable]
        public struct Pool
        {
            public GameObject objectPrefab;
            public int poolSize;
            public Transform pooledObjectParent;
            public Queue<GameObject> pooledObjects;    
        }

        [SerializeField] private Pool[] pools = null;
        
        private void Awake()
        {
           CreatePools();
        }
        private void CreatePools()
        {
            for (int j = 0; j < pools.Length; j++)
            {
                pools[j].pooledObjects = new Queue<GameObject>();

                for (int i = 0; i < pools[j].poolSize; i++)
                {
                    GameObject obj = Instantiate(pools[j].objectPrefab, pools[j].pooledObjectParent);

                    obj.SetActive(false);
                    
                    pools[j].pooledObjects.Enqueue(obj);
                }
            }
        }

        public GameObject GetPooledObject(int objectType)
        {
            if (objectType >= pools.Length)
            {
                return null;
            }

            GameObject obj;
            
            if (pools[objectType].pooledObjects.Count == 0)
            {
                obj = Instantiate(pools[objectType].objectPrefab, pools[objectType].pooledObjectParent);
            }
            else
            {
                obj = pools[objectType].pooledObjects.Dequeue();
            }

            obj.SetActive(true);

            return obj;
        }

        public void ReturnToPool(int objectType, GameObject obj)
        {
            if (objectType >= pools.Length)
            {
                return;
            }
            
            obj.SetActive(false);
            
            pools[objectType].pooledObjects.Enqueue(obj);
        }
    }
}
