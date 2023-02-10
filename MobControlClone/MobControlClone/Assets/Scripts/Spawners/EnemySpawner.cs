using System;
using System.Collections;
using Enemies;
using UnityEngine;
using Utilities;

namespace Spawners
{
    public class EnemySpawner:MonoBehaviour
    {
        [Header("Spawner Settings")]
        
        [Space(5)]
        
        [SerializeField] private Transform spawnPos;
        [SerializeField] private Transform targetBuilding;
        [SerializeField] private float enemySpawnTime;
        [SerializeField] private int enemyGroupSize;
        
        private ObjectPool _objectPool;

        private void Awake()
        {
            _objectPool = FindObjectOfType<ObjectPool>();
        }

        private void Start()
        {
            StartCoroutine(EnemySpawnRoutine());
        }

        private IEnumerator EnemySpawnRoutine()
        {
            yield return new WaitForSeconds(0.2f);
            
            while (true)
            {
                for (int i = 0; i < enemyGroupSize; i++)
                {
                    GameObject newEnemy = _objectPool.GetPooledObject(1);
                    newEnemy.transform.position = spawnPos.position;
                    newEnemy.GetComponent<GoblinEnemy>().targetBuilding = targetBuilding;
                }
                yield return new WaitForSeconds(enemySpawnTime);
            }
        }
    }
}