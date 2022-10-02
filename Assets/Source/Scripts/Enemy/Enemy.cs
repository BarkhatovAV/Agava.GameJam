using BehaviorDesigner.Runtime;
using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(EnemyAttacker), typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyVision), typeof(BehaviorTree))]
public class Enemy : PoolObject
{
    private EnemyMover _mover;
    private EnemyAttacker _attacker;
    private BehaviorTree _behaviorTree;
    private EnemyHealth _health;
    private EnemyVision _vision;

    public event Action<Vector3> Died;

    private void OnEnable()
    {
        _health.Ended += OnHealthEnded;
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Ended -= OnHealthEnded;
        _health.Died -= OnDied;
    }

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _attacker = GetComponent<EnemyAttacker>();
        _behaviorTree = GetComponent<BehaviorTree>();
        _health = GetComponent<EnemyHealth>();
        _vision = GetComponent<EnemyVision>();
    }

    public void Initialize(ITarget target)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        _mover.Initialize(target);
        _attacker.Initialize(target);
        _vision.Initialize(target);
    }

    public void Apply(int damage)
    {
        _health.Apply(damage);
    }

    private void OnHealthEnded()
    {
        _behaviorTree.enabled = false;
        _mover.StopMoving();
        _attacker.StopAttack();
    }

    private void OnDied()
    {
        Died?.Invoke(transform.position);
        Deactivate();
    }
}