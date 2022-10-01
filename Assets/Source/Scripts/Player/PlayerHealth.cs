using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITarget
{
    [Min(0)]
    [SerializeField] private int _value = 100;

    public Vector3 CurrentPosition => transform.position;
    public int MaxHealth { get; private set; }

    public event Action<float> HealthChanged;
    public event Action Died;

    private void Start()
    {
        MaxHealth = _value;
    }

    public void Apply(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _value -= damage;
        HealthChanged?.Invoke(_value);

        if (_value <= 0)
            Died?.Invoke();
    }
}
