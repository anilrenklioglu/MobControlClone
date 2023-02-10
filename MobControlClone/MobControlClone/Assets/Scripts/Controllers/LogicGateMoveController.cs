using System;
using UnityEngine;
using DG.Tweening;

namespace Controllers
{
    public class LogicGateMoveController : MonoBehaviour
    {
        [SerializeField] private float moveTime;
        [SerializeField] private float moveDistance;

        private float _startingPosX;

        private void Awake()
        {
            _startingPosX = transform.position.x;
        }

        private void Start()
        {
            Move();
        }

        private void Move()
        {
            transform.DOMoveX(_startingPosX + moveDistance, moveTime).SetLoops(-1,LoopType.Yoyo);
        }
    }
}
