using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private ITarget _target;

    public int DistanceToTarget { get; }

    public void Initialize(ITarget target)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        _target = target;
    }

    public void MoveToTarget()
    {

    }

    public void StopMoving()
    {
        
    }
}