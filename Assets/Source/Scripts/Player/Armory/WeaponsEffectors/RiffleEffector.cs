using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(IReloadable))]
public class RiffleEffector : WeaponEffector
{
    [SerializeField] private ParticleSystem _particleBulletsShells;
    [SerializeField] private ParticleSystem _particleFire;

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
        _reloadable.ReloadStarted += OnReloadStarted;
        _reloadable.ReloadFinished += OnReloadFinished;
    }

    private void OnDisable()
    {
        _reloadable.ReloadStarted -= OnReloadStarted;
        _reloadable.ReloadFinished -= OnReloadFinished;
    }

    protected override void StartPlayEffects()
    {
        if(_isEffectsEnable == true)
        {
            _audioEffect.Play();
            PlayParticles();
        }
    }

    protected override void StopPlayEffects()
    {
        _audioEffect?.Stop();
        StopPlayParticles();
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
