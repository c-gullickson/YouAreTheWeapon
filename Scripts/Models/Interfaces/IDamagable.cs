using Constants;

namespace Models.Interfaces
{
    public interface IDamagable
    {
        public void Damage(StatType statType, float damage);
    }
}