using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Transform targetBuilding;
        
        private int health;
        private int _currentHealth;

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
