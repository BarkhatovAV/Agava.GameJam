using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected int _damage;
    [SerializeField] private float _delayBetweenShots;

    protected float _lastTimeShot;

    public event Action<int> DamageDealed;
    public event Action Fired;

    public virtual void Fire(Collider collider = null)
    {
        Fired?.Invoke();

        if ((collider != null) && (collider.TryGetComponent(out Enemy enemy)))
        {
            enemy.Apply(_damage);
            DamageDealed(_damage);
        }
    }

    protected void DealingDamage(int damage)
    {
        DamageDealed?.Invoke(damage);
    }

    protected bool CheckDelay()
    {
        if(_lastTimeShot + _delayBetweenShots < Time.time)
        {
            _lastTimeShot = Time.time;
            return true;
        }
        else
            return false;            
    }
}
