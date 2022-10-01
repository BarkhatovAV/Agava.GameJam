using BehaviorDesigner.Runtime;
using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(EnemyAttacker), typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _mover;
    private EnemyAttacker _attacker;
    private EnemyHealth _health;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _attacker = GetComponent<EnemyAttacker>();
        _health = GetComponent<EnemyHealth>();
    }

    public void Initialize(ITarget target)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        _mover.Initialize(target);
        _attacker.Initialize(target);
    }


    public void Apply(int damage)
    {
        _health.Apply(damage);
    }
}