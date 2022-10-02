using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyHealth : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private int _startValue;
    [Min(0)]
    [SerializeField] private float _delayBeforeDeath;
    [SerializeField] private ParticleSystem _bloodFromHit;
    [SerializeField] private ParticleSystem _bloodExplosion;

    private Animator _animator;
    private int _currentValue;

    public event Action Ended;
    public event Action Died;

    public float DelayBeforeDeath => _delayBeforeDeath;

    private void OnEnable()
    {
        _currentValue = _startValue;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Apply(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        if (_currentValue <= 0)
            return;

        _currentValue -= damage;
        _bloodFromHit.Play();

        if (_currentValue <= 0)
            StartCoroutine(Die());
    }

    public void Kill()
    {
        Apply(_currentValue);
    }

    private IEnumerator Die()
    {
        Ended?.Invoke();
        _animator.SetBool(EnemyAnimator.Params.IsDying, true);
        yield return new WaitForSeconds(_delayBeforeDeath);
        Instantiate(_bloodExplosion, transform.position, _bloodExplosion.transform.rotation);
        Died?.Invoke();
    }
}