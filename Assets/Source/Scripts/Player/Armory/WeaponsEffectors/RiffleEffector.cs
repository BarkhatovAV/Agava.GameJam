using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RiffleEffector : WeaponEffector
{
    [SerializeField] private ParticleSystem _particleBulletsShells;
    [SerializeField] private ParticleSystem _particleFire;

    private AudioSource _audioEffect;

    private void Awake()
    {
        _audioEffect = GetComponent<AudioSource>();
        StopPlayParticles();
    }

    protected override void StartPlayEffects()
    {
        _audioEffect.Play();
        PlayParticles();
    }

    protected override void StopPlayEffects()
    {
        _audioEffect?.Stop();
        StopPlayParticles();
    }

    private void PlayParticles()
    {
        _particleBulletsShells.Play();
        _particleFire.Play();
    }

    private void StopPlayParticles()
    {
        _particleBulletsShells.Stop();
        _particleFire.Stop();
    }
}
