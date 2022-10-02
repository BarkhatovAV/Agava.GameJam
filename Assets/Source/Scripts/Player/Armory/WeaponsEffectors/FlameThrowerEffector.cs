using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FlameThrowerEffector : WeaponEffector
{
    [SerializeField] private ParticleSystem _particleFlame;

    private AudioSource _audioEffect;

    private void Awake()
    {
        _audioEffect = GetComponent<AudioSource>();
        _particleFlame.Stop();
    }

    protected override void StartPlayEffects()
    {
        _particleFlame.Play();
        _audioEffect.Play();
    }

    protected override void StopPlayEffects()
    {
        _particleFlame.Stop();
        _audioEffect.Stop();
    }
}
