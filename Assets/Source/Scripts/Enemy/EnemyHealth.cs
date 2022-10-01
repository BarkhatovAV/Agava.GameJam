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
    [SerializeField] private ParticleSystem _bloodFromHit;
    [SerializeField] private ParticleSystem _bloodExplosion;

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

        if (_value <= 0)
            return;

        _value -= damage;
        _bloodFromHit.Play();

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
        Instantiate(_bloodExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}