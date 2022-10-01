using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] protected float _shotDistance;
    [SerializeField] private float _delayBetweenShots;
   
    public virtual void Fire(RaycastHit hitInfo)
    {
        if (hitInfo.collider.TryGetComponent(out Ground ground) && _shotDistance > hitInfo.distance)
            print(hitInfo.distance);
    }
}
