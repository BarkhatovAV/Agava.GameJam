using UnityEngine;

public class SoundMuteHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnValidate()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnEnable()
    {
        _playerHealth.Died += Stop;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= Stop;
    }

    public void Stop()
    {
        _audio.Stop();
    }

    public void Play()
    {
        _audio.Play();
    }
}
