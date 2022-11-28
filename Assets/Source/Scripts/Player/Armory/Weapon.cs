using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected int _damage;
    [SerializeField] private float _delayBetweenShots;

    protected float _lastTimeShot;

    public event Action<int> DamageDealed;

    public virtual void Fire(RaycastHit hitInfo)
    {
        print(hitInfo.collider);

        if (hitInfo.collider.TryGetComponent(out Enemy enemy))
            enemy.Apply(_damage);
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
