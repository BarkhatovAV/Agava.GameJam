using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITarget
{
    [Range(0, 100)]
    [SerializeField] private int _value = 100;
    [SerializeField] private GameObject _visualImmortalBoost;

    private int _criticalHealthLevel = 50;
    private int _maxHealth = 100;
    private bool _isDamageable;
    private Coroutine _coroutine;

    public Vector3 CurrentPosition => transform.position;
    public int MaxHealth => _maxHealth;

    public event Action<float> HealthChanged;
    public event Action Died;
    public event Action HealthCriticallyReduced;

    private void Awake()
    {
        _isDamageable = true;
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

        _value += health;

        if (_value >= _maxHealth)
            _value = _maxHealth;

        HealthChanged?.Invoke(_value);
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
        _value -= damage;
        HealthChanged?.Invoke(_value);

        if (_value <= _criticalHealthLevel)
        {
            HealthCriticallyReduced?.Invoke();
        }

        if (_value <= 0)
        {
            if (this.enabled)
            {
                Died?.Invoke();
            }

            this.enabled = false;
        }
    }
}
