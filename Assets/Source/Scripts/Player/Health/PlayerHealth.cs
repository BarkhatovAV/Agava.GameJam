using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITarget
{
    [Range(0, 100)]
    [SerializeField] private int _value = 100;

    private int _criticalHealthLevel = 50;
    private int _maxHealth = 100;

    public Vector3 CurrentPosition => transform.position;
    public int MaxHealth => _maxHealth;

    public event Action<float> HealthChanged;
    public event Action Died;
    public event Action HealthCriticallyReduced;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            Died?.Invoke();
    }

    public void Apply(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _value -= damage;
        HealthChanged?.Invoke(_value);

        if (_value <= _criticalHealthLevel)
        {
            HealthCriticallyReduced?.Invoke();
        }

        if (_value <= 0)
        {
            Died?.Invoke();
            this.enabled = false;
        }

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
}
