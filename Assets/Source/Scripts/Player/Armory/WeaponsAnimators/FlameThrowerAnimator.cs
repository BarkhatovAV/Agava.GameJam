using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FlameThrowerAnimator : WeaponAnimator
{
    [SerializeField] private ParticleSystem _particleFlame;

    private AudioSource _audioEffect;

    private void Awake()
    {
        _audioEffect = GetComponent<AudioSource>();
        _particleFlame.Stop();
    }

    protected override void StartAnimation()
    {
        _particleFlame.Play();
        _audioEffect.Play();
    }

    protected override void StopAnimation()
    {
        _particleFlame.Stop();
        _audioEffect.Stop();
    }
}
