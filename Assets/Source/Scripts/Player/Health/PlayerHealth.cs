using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITarget
{
    [Range(0, 100)]
    [SerializeField] private int _maxValue = 100;
    [SerializeField] private GameObject _visualImmortalBoost;

    private int _criticalHealthLevel = 50;
    private int _currentValue;
    private bool _isDamageable;
    private Coroutine _coroutine;

    public Vector3 CurrentPosition => transform.position;

    public event Action<float, float> HealthChanged;
    public event Action Died;
    public event Action HealthCriticallyReduced;

    private void Awake()
    {
        _isDamageable = true;
        _currentValue = _maxValue;
    }

    private void Start()
    {
        HealthChanged?.Invoke(_currentValue, _maxValue);
    }

    public void TryTakeDamage(int damage)
    {
        if ((_isDamageable == true) && (damage > 0))
            TakeDamage(damage);
    }

    public void Heal(int health)
    {
        if (health < 0)
            throw new ArgumentOutOfRangeException(nameof(health));

        _currentValue = Mathf.Clamp(_currentValue + health, 0, _maxValue);

        HealthChanged?.Invoke(_currentValue, _maxValue);
    }

    public void TakeBoost(float duration)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnBoosted(duration));
    }

    private IEnumerator OnBoosted(float duration)
    {
        _isDamageable = false;
        _visualImmortalBoost.SetActive(true);
        yield return new WaitForSeconds(duration);
        _visualImmortalBoost.SetActive(false);
        _isDamageable = true;
    }

    private void TakeDamage(int damage)
    {
        _currentValue -= damage;
        HealthChanged?.Invoke(_currentValue, _maxValue);

        if (_currentValue <= _criticalHealthLevel)
        {
            HealthCriticallyReduced?.Invoke();
        }

        if (_currentValue <= 0)
        {
            if (this.enabled)
            {
                Died?.Invoke();
            }

            this.enabled = false;
        }
    }
}
