using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerAnimator : WeaponAnimator
{
    [SerializeField] private ParticleSystem _particleFlame;

    private void Awake()
    {
        _particleFlame.Stop();
    }

    protected override void StartAnimation()
    {
        _particleFlame.Play();
    }

    protected override void StopAnimation()
    {
        _particleFlame.Stop();
    }
}
