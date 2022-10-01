using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ChainSawAnimator : WeaponAnimator
{
    private Animator _animator;
    private const string c_ShakeSaw = "ShakeSaw";
    private const string c_Idle = "ChainSawIdle";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(c_Idle);
    }

    protected override void StartAnimation()
    {
        _animator.Play(c_ShakeSaw);
    }

    protected override void StopAnimation()
    {
        _animator.Play(c_Idle);
    }
}
