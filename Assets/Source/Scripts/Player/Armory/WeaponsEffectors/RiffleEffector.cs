using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RiffleEffector : WeaponEffector
{
    [SerializeField] private ParticleSystem _particleBulletsShells;

    private AudioSource _audioEffect;

    private void Awake()
    {
        _audioEffect = GetComponent<AudioSource>();
        _particleBulletsShells.Stop();
    }

    protected override void StartPlayEffects()
    {
        _audioEffect.Play();
        _particleBulletsShells.Play();
    }

    protected override void StopPlayEffects()
    {
        _audioEffect?.Stop();
        _particleBulletsShells.Stop();
    }
}
