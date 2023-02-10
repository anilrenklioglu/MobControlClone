
using UnityEngine;
using UnityEngine.AI;

namespace Soldier
{
    public abstract class SoldierBase : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Transform targetBuilding;
        public bool isBoss;
        private void OnEnable()
        {
            MoveToTarget(targetBuilding);
        }
        
        private void MoveToTarget(Transform target)
        {
            agent.SetDestination(target.position);
        }
    }
}
