using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private ITarget _target;
    private RaycastHit _raycastHit;
    private Ray _ray;

    public bool TargetIsVisible { get; private set; }
    public float DistanceToTarget 
        => Vector3.Distance(transform.position, _target.CurrentPosition);

    public void Initialize(ITarget target)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        _target = target;
    }

    private void Update()
    {
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        _ray = new Ray(transform.position, DirectionToTarget());

        if (Physics.Raycast(_ray, out _raycastHit, DistanceToTarget, _layerMask))
        {
            if (_raycastHit.collider.gameObject.TryGetComponent(out ITarget _))
                TargetIsVisible = true;
            else
                TargetIsVisible = false;
        }
    }

    private Vector3 DirectionToTarget()
        => (_target.CurrentPosition - transform.position).normalized;
}