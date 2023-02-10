using UnityEngine;
using Utilities;

namespace Cannon
{
    public class CannonMovementController : SingletonMonobehaviour<CannonMovementController>
    {
        private Vector3 _firstPos;
        private bool _firstTouch;
        private Vector3 _secondPos;
        private bool _canMove;

        [SerializeField] private float moveSpeed;
        [SerializeField] private float moveLimitX;

        
        private void Update()
        {
            Movement();
        }
        
        public void Movement()
        {
            if (Input.GetMouseButton(0))
            {
                if (!_firstTouch)
                {
                    _firstPos = Input.mousePosition;
                    _secondPos = _firstPos;
                    _firstTouch = true;
                }
                else if (_firstTouch)
                {
                    _secondPos = Input.mousePosition;
                    
                    Vector3 deltaPos = _secondPos - _firstPos;
                    
                    _firstPos = _secondPos;

                    Vector3 position = transform.position;
                    
                    Vector3 pos = position;

                    float sW = Screen.width;
                   
                    pos.x += (deltaPos.x / sW) * 500 * Time.deltaTime * moveSpeed;


                    pos = new Vector3(Mathf.Clamp(pos.x, -moveLimitX, moveLimitX), position.y, 
                        position.z);

                    position = pos;
                    
                    transform.position = position;
                }
            }
            else
            {
                _firstTouch = false;
                _firstPos = Vector3.zero;
                _secondPos = Vector3.zero;
            }
        }
    } 
}