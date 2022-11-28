using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class EnemyMover : MonoBehaviour
{
    private ITarget _target;
    private NavMeshAgent _agent;
    private Animator _animator;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
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
        _animator.SetBool(EnemyAnimator.Params.IsRunning, true);

        if (_agent.isActiveAndEnabled)
            _agent.SetDestination(_target.CurrentPosition);
    }

    public void StopMoving()
    {
        _agent.isStopped = true;
        _animator.SetBool(EnemyAnimator.Params.IsRunning, false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MoveSlower slower))
            _agent.speed *= 0.5f;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out MoveSlower slower))
            _agent.speed *= 2f;            
    }
}