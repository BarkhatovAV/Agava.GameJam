using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _reloadTime;
    [SerializeField] protected float _shotDistance;
    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem.Stop();
    }
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _particleSystem.Play();
        if (Input.GetMouseButtonUp(0))
            _particleSystem.Stop();
    }
}
