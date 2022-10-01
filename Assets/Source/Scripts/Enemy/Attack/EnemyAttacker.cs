using System;
using UnityEngine;

public abstract class EnemyAttacker : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private float _secondsBetweenAttack;

    private ITarget _target;

    protected float SecondsBetweenAttack => _secondsBetweenAttack;
    protected float ElapsedTime { get; private set; }

    public void Initialize(ITarget target)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        _target = target;
    }

    public void Attack()
    {
        ElapsedTime += Time.deltaTime;

        if (ConditionBeforeAttack())
        {
            Attack(_target);
            StopAttack();
        }
    }

    public void StopAttack()
    {
        ElapsedTime = 0;
    }

    protected abstract void Attack(ITarget target);

    protected abstract bool ConditionBeforeAttack();
}