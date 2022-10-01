using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] protected float _shotDistance;
    [SerializeField] private float _delayBetweenShots;

    protected float _lastTimeShot;

    public virtual void Fire(RaycastHit hitInfo)
    {
        if (hitInfo.collider.TryGetComponent(out Ground ground) && (_shotDistance > hitInfo.distance))
            print(hitInfo.distance);
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
