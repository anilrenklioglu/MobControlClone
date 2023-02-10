using UnityEngine;

namespace Interfaces
{
    public interface IAttacker<T>
    {
        int DamagePower { get; set; }
        void Attack(GameObject target,int damage);
    }
}