using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MachineGunEffector : WeaponEffector
{
    [SerializeField] private float _changeRotateSpeed;
    [SerializeField] private float _changeColorSpeed;
    [SerializeField] private float _maxBarrelSpeed;
    [SerializeField] private Material _material;
    [SerializeField] private ParticleSystem _particleBulletsShells;
    [SerializeField] private ParticleSystem _particleFire;

    private Animator _animator;
    private AudioSource _audioEffect;
    private Coroutine _coroutineRotate;
    private Coroutine _coroutinColorChange;
    private IReloadable _reloadable;
    private bool _isEffectsEnable;


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _audioEffect = GetComponentInChildren<AudioSource>();
        _reloadable = GetComponent<IReloadable>();
        _isEffectsEnable = true;
    }

    private void OnEnable()
    {
        _animator.speed = 0;
        _material.color = Color.white;
        StopPlayParticles();
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
        if( _isEffectsEnable == true)
        {
            ChangeBarrelRotateSpeed(_maxBarrelSpeed);
            ChangeBarrelColor(Color.red);
            _audioEffect.Play();
            PlayParticles();
        }
    }

    protected override void StopPlayEffects()
    {
        ChangeBarrelRotateSpeed(0);
        ChangeBarrelColor(Color.white);
        _audioEffect.Stop();
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


    private void ChangeBarrelColor(Color targetColor)
    {
        if (_coroutinColorChange != null)
            StopCoroutine(_coroutinColorChange);

        _coroutinColorChange = StartCoroutine(OnBarrelColorChange(targetColor));
    }

    private void ChangeBarrelRotateSpeed(float targetSpeed)
    {
        if (_coroutineRotate != null)
            StopCoroutine(_coroutineRotate);

        _coroutineRotate = StartCoroutine(OnRotateBarrel(targetSpeed));
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

    private IEnumerator OnRotateBarrel(float targetSpeed)
    {
        while(_animator.speed != targetSpeed)
        {
            _animator.speed = Mathf.Lerp(_animator.speed, targetSpeed, _changeRotateSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator OnBarrelColorChange(Color targetColor)
    {
        while(_material.color != targetColor)
        {
            Color color = _material.color;
            color.g = Mathf.Lerp(color.g, targetColor.g, _changeColorSpeed * Time.deltaTime);
            color.b = Mathf.Lerp(color.b, targetColor.b, _changeColorSpeed * Time.deltaTime);
            _material.color = color;

            yield return new WaitForSeconds(0.05f);
        }
    }
}
