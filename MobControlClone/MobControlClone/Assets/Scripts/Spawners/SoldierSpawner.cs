using System.Collections;
using UnityEngine;
using Soldier;
using Utilities;
using DG.Tweening;

namespace Spawners
{
    public class SoldierSpawner : MonoBehaviour
    {
        [Header("Spawner Settings")]
        [Space(5)]
        
        [SerializeField] private Transform spawnPos;
       // [SerializeField] private Transform targetBuilding;
        [SerializeField] private float soldierSpawnTime;

        private float _spawnTimer;
        
        private ObjectPool _objectPool;
        private Tweener _tweener;
        private void Awake()
        {
            _objectPool = FindObjectOfType<ObjectPool>();
        }
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _spawnTimer += Time.deltaTime;
                
                if (_spawnTimer >= soldierSpawnTime)
                {
                    GameObject newSoldier = _objectPool.GetPooledObject(0);
                    newSoldier.transform.position = spawnPos.position;
                   // newSoldier.GetComponent<WarriorSoldier>().targetBuilding = targetBuilding;
                    Vector3 originalScale = newSoldier.transform.localScale;
            
                    _tweener = newSoldier.transform.DOScale(originalScale *1.4f, 0.5f).SetEase(Ease.InOutSine).OnComplete((() =>
                    {
                        newSoldier.transform.localScale = originalScale;

                        newSoldier.transform.DOKill();
                    }));
                    _spawnTimer = 0;
                }
            }
           
        }
    }
}
