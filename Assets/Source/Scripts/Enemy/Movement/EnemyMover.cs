using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMover : MonoBehaviour
{
    private ITarget _target;
    private NavMeshAgent _agent;

    public float DistanceToTarget => Vector3.Distance(transform.position, _target.CurrentPosition);
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Initialize(ITarget target)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        _target = target;
    }

    public void MoveToTarget()
    {
        _agent.isStopped = false;

        if (_agent.isActiveAndEnabled)
            _agent.SetDestination(_target.CurrentPosition);
    }

    public void StopMoving()
    {
        _agent.isStopped = true;
    }
}