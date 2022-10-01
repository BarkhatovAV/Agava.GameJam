using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunAnimator : WeaponAnimator
{
    [SerializeField] private float _stepChangeBarrelSpeed;
    [SerializeField] private float _maxBarrelSpeed;

    private Animator _animator;
    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        _animator.speed = 0;
    }

    protected override void StartAnimation()
    {
        ChangeBarrelRotateSpeed(_maxBarrelSpeed);
    }

    protected override void StopAnimation()
    {
        ChangeBarrelRotateSpeed(0);
    }

    private void ChangeBarrelRotateSpeed(float targetSpeed)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnRotateBarrel(targetSpeed));
    }

    private IEnumerator OnRotateBarrel(float targetSpeed)
    {
        while(_animator.speed != targetSpeed)
        {
            _animator.speed = Mathf.Lerp(_animator.speed, targetSpeed, _stepChangeBarrelSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
