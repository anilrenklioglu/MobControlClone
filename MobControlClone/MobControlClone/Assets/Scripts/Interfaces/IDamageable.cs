namespace Interfaces
{
    public interface IDamageable<T>
    { 
        T Health { get; set; }
        
        void TakeDamage(int damage);
    }
}


