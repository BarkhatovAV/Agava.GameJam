using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(EnemyAttacker))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _mover;
    private EnemyAttacker _attacker;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _attacker = GetComponent<EnemyAttacker>();
    }

    public void Initialize(ITarget target)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        _mover.Initialize(target);
        _attacker.Initialize(target);
    }
}