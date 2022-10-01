using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private int _value;
    [Min(0)]
    [SerializeField] private float _delayBeforeDeath;

    public event UnityAction Ended;

    public void Apply(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _value -= damage;

        if (_value <= 0)
            StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        Ended?.Invoke();
        yield return new WaitForSeconds(_delayBeforeDeath);
        Destroy(gameObject);
    }
}