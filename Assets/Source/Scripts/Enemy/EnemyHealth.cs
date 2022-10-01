using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class EnemyHealth : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private int _value;
    [Min(0)]
    [SerializeField] private float _delayBeforeDeath;

    private Animator _animator;

    public event UnityAction Ended;

    public float DelayBeforeDeath => _delayBeforeDeath;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Apply(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _value -= damage;

        if (_value <= 0)
            StartCoroutine(Die());
    }

    public void Kill()
    {
        Apply(_value);
    }

    private IEnumerator Die()
    {
        Ended?.Invoke();
        _animator.SetBool(EnemyAnimator.Params.IsDying, true);
        yield return new WaitForSeconds(_delayBeforeDeath);
        Destroy(gameObject);
    }
}