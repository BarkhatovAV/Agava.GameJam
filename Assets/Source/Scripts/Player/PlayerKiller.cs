using System.Collections;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    [SerializeField] private PlayerMovement _mover;
    [SerializeField] private PlayerShooter _shooter;
    [SerializeField] private PlayerViewRotator _viewRotator;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private float _fallingSpeed;
    [SerializeField] private float _timeScaleOnDie;

    private float _fallAngle = -90;
    private Quaternion _dieRotarion;

    private void OnValidate()
    {
        _mover = FindObjectOfType<PlayerMovement>();
        _shooter = FindObjectOfType<PlayerShooter>();
        _viewRotator = FindObjectOfType<PlayerViewRotator>();
        _health = FindObjectOfType<PlayerHealth>();
    }

    private void Awake()
    {
        _dieRotarion = Quaternion.Euler(_fallAngle, 0, 0);
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
        _viewRotator.enabled = false;
        _shooter.enabled = false;
        _mover.enabled = false;
        Time.timeScale = _timeScaleOnDie;

        StartCoroutine(OnFall());
    }

    private void Fall()
    {
        _health.transform.rotation = Quaternion.Lerp(_health.transform.rotation, _dieRotarion, _fallingSpeed * Time.deltaTime);
    }

    private IEnumerator OnFall()
    {
        while(_health.transform.rotation != _dieRotarion)
        {
            Fall();

            yield return new WaitForSeconds(0.01f);
        }
    }
}
