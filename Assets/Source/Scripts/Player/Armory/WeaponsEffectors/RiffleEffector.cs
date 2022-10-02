using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RiffleEffector : WeaponEffector
{
    private AudioSource _audioEffect;

    private void Awake()
    {
        _audioEffect = GetComponent<AudioSource>();
    }

    protected override void StartPlayEffects()
    {
        _audioEffect.Play();
    }

    protected override void StopPlayEffects()
    {
        _audioEffect?.Stop();
    }
}
