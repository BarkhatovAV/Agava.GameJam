using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class ChainSawEffector : WeaponEffector
{
    [SerializeField] private AudioClip _audioSawIdle;
    [SerializeField] private AudioClip _audioSawAttack;
    [SerializeField] private ParticleSystem _particleBlood;

    private AudioSource _audioEffect;
    private Collider _collider;
    

    private Animator _animator;
    private const string c_ShakeSaw = "ShakeSaw";
    private const string c_Idle = "ChainSawIdle";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioEffect = GetComponent<AudioSource>();
        _collider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        _animator.Play(c_Idle);
        ChangeAudioEffect(_audioSawIdle);
        _particleBlood.Stop();
        _collider.enabled = false;
    }

    protected override void StartPlayEffects()
    {
        _animator.Play(c_ShakeSaw);
        ChangeAudioEffect(_audioSawAttack);
        _collider.enabled = true;
    }

    protected override void StopPlayEffects()
    {
        ChangeAudioEffect(_audioSawIdle);
        _animator.Play(c_Idle);
        _collider.enabled = false;
        _particleBlood.Stop();
    }

    private void ChangeAudioEffect(AudioClip audio)
    {
        _audioEffect.clip = audio;
        _audioEffect.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out Ground ground))
            _particleBlood.Play();
    }
}
