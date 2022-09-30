using System;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private int _damage;
    [Min(0)]
    [SerializeField] private float _secondsBetweenAttack;

    private ITarget _target;
    private float _elapsedTime;

    public void Initialize(ITarget target)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        _target = target;
    }

    public void Attack()
    {
        _elapsedTime = Time.deltaTime;

        if (_elapsedTime > _secondsBetweenAttack)
        {
            _target.Apply(_damage);
            StopAttack();
        }
    }

    public void StopAttack() 
        => _elapsedTime = 0;
}