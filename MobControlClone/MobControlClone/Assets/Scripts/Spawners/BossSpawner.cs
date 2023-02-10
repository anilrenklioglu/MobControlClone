using UnityEngine;
using Utilities;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

namespace Spawners
{
    public class BossSpawner : MonoBehaviour
    {
        [Header("Spawner Settings")]
        [Space(5)]
        
        [SerializeField] private Transform spawnPos;
        [SerializeField] private Image bar;
        [SerializeField] private float barFillRate;

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
                bar.fillAmount += barFillRate * Time.deltaTime;
                
                if (bar.fillAmount >= 1)
                {
                    bar.fillAmount = 0;
                    
                    GameObject newSoldier = _objectPool.GetPooledObject(2);
                    newSoldier.transform.position = spawnPos.position;
                    // newSoldier.GetComponent<WarriorSoldier>().targetBuilding = targetBuilding;
                    Vector3 originalScale = newSoldier.transform.localScale;
            
                    _tweener = newSoldier.transform.DOScale(originalScale *1.4f, 0.5f).SetEase(Ease.InOutSine).OnComplete((() =>
                    {
                        newSoldier.transform.localScale = originalScale;

                        newSoldier.transform.DOKill();
                    }));
                }
            }
        }
    }
}
