using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDiePlayer : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;

    private AudioSource _audioPlayerDie;


    private void OnValidate()
    {
        _health = FindObjectOfType<PlayerHealth>();
    }

    private void Awake()
    {
        _audioPlayerDie = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void OnDied()
    {
        _audioPlayerDie.Play();
    }
}
