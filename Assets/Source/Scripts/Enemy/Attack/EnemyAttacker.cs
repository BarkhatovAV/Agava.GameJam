using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class EnemyAttacker : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private float _secondsBetweenAttack;

    private ITarget _target;
    private Animator _animator;

    protected float SecondsBetweenAttack => _secondsBetweenAttack;
    protected float ElapsedTime { get; private set; }

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Initialize(ITarget target)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        _target = target;
    }

    public void Attack()
    {
        ElapsedTime += Time.deltaTime;
        _animator.SetBool(EnemyAnimator.Params.IsAttacking, true);

        if (ConditionBeforeAttack())
        {
            Attack(_target);
            StopAttack();
        }
    }

    public void StopAttack()
    {
        ElapsedTime = 0;
        _animator.SetBool(EnemyAnimator.Params.IsAttacking, false);
    }

    protected abstract void Attack(ITarget target);

    protected abstract bool ConditionBeforeAttack();
}