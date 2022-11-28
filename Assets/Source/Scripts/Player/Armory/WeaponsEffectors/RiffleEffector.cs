using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(IReloadable))]
public class RiffleEffector : WeaponEffector
{
    [SerializeField] private ParticleSystem _particleBulletsShells;
    [SerializeField] private ParticleSystem _particleFire;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private SpawnerBullets _spawner;
    [SerializeField] private Transform _shootPoint;


    private AudioSource _audioEffect;
    private IReloadable _reloadable;
    private bool _isEffectsEnable;

    private void Awake()
    {
        _audioEffect = GetComponent<AudioSource>();
        StopPlayParticles();
        _reloadable = GetComponent<IReloadable>();
        _isEffectsEnable = true;
    }

    private void OnEnable()
    {
        StopPlayEffects();
        ReturnOnBaseTransform();
        _reloadable.ReloadStarted += OnReloadStarted;
        _reloadable.ReloadFinished += OnReloadFinished;
        _weapon.Fired += OnFired;
    }

    private void OnDisable()
    {
        _reloadable.ReloadStarted -= OnReloadStarted;
        _reloadable.ReloadFinished -= OnReloadFinished;
        _weapon.Fired -= OnFired;
    }

    private void OnFired()
    {
        _spawner.Spawn(_shootPoint);
    }

    protected override void StartPlayEffects()
    {
        if(_isEffectsEnable == true)
        {
            _audioEffect.Play();
            PlayParticles();
            StartAnimateShotRecoil();
        }
    }

    protected override void StopPlayEffects()
    {
        _audioEffect?.Stop();
        StopPlayParticles();
        StoptAnimateShotRecoil();
    }

    private void OnReloadStarted(float reloadTime)
    {
        StopPlayEffects();
        Reload(reloadTime);
        _isEffectsEnable = false;
    }

    private void OnReloadFinished()
    {
        _isEffectsEnable = true;

        if (Input.GetMouseButton(0))
            StartPlayEffects();
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
