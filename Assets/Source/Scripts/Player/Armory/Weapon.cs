using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] protected float _shotDistance;
    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem.Stop();
    }
    
    public virtual void Fire(RaycastHit hitInfo)
    {
        if (hitInfo.collider.TryGetComponent(out Ground ground) && _shotDistance > hitInfo.distance)
            print(hitInfo.distance);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _particleSystem.Play();
        if (Input.GetMouseButtonUp(0))
            _particleSystem.Stop();
    }
}
