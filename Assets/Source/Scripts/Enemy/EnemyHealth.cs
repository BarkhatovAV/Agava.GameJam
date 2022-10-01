using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private int _value;

    public void Apply(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _value -= damage;
    }
}