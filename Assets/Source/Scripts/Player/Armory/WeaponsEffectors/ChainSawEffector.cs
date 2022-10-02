using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class ChainSawEffector : WeaponEffector
{
    [SerializeField] private AudioClip _audioSawIdle;
    [SerializeField] private AudioClip _audioSawAttack;

    AudioSource _audioEffect;
    

    private Animator _animator;
    private const string c_ShakeSaw = "ShakeSaw";
    private const string c_Idle = "ChainSawIdle";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioEffect = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _animator.Play(c_Idle);
        ChangeAudioEffect(_audioSawIdle);
    }

    protected override void StartPlayEffects()
    {
        _animator.Play(c_ShakeSaw);
        ChangeAudioEffect(_audioSawAttack);
    }

    protected override void StopPlayEffects()
    {
        ChangeAudioEffect(_audioSawIdle);
        _animator.Play(c_Idle);
    }

    private void ChangeAudioEffect(AudioClip audio)
    {
        _audioEffect.clip = audio;
        _audioEffect.Play();
    }
}
