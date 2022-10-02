using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class ChainSawEffector : WeaponEffector
{
    AudioSource _audioEffectAttack;

    private Animator _animator;
    private const string c_ShakeSaw = "ShakeSaw";
    private const string c_Idle = "ChainSawIdle";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioEffectAttack = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _animator.Play(c_Idle);
    }

    protected override void StartPlayEffects()
    {
        _animator.Play(c_ShakeSaw);
        _audioEffectAttack.Play();
    }

    protected override void StopPlayEffects()
    {
        _audioEffectAttack.Stop();
        _animator.Play(c_Idle);
    }
}
