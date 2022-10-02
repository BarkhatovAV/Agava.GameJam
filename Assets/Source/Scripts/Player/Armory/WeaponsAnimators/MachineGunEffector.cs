using System.Collections;
using UnityEngine;

public class MachineGunEffector : WeaponEffector
{
    [SerializeField] private float _changeRotateSpeed;
    [SerializeField] private float _changeColorSpeed;
    [SerializeField] private float _maxBarrelSpeed;
    [SerializeField] private Material _material;

    private Animator _animator;
    private Coroutine _coroutineRotate;
    private Coroutine _coroutinColorChange;


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        _animator.speed = 0;
        _material.color = Color.white;
    }

    protected override void StartAnimation()
    {
        ChangeBarrelRotateSpeed(_maxBarrelSpeed);
        ChangeBarrelColor(Color.red);
    }

    protected override void StopAnimation()
    {
        ChangeBarrelRotateSpeed(0);
        ChangeBarrelColor(Color.white);
    }

    private void ChangeBarrelColor(Color targetColor)
    {
        if (_coroutinColorChange != null)
            StopCoroutine(_coroutinColorChange);

        _coroutineRotate = StartCoroutine(OnBarrelColorChange(targetColor));
    }

    private void ChangeBarrelRotateSpeed(float targetSpeed)
    {
        if (_coroutineRotate != null)
            StopCoroutine(_coroutineRotate);

        _coroutineRotate = StartCoroutine(OnRotateBarrel(targetSpeed));
    }

    private IEnumerator OnRotateBarrel(float targetSpeed)
    {
        while(_animator.speed != targetSpeed)
        {
            _animator.speed = Mathf.Lerp(_animator.speed, targetSpeed, _changeRotateSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator OnBarrelColorChange(Color targetColor)
    {
        while(_material.color != targetColor)
        {
            Color color = _material.color;
            color.g = Mathf.Lerp(color.g, targetColor.g, _changeColorSpeed * Time.deltaTime);
            color.b = Mathf.Lerp(color.b, targetColor.b, _changeColorSpeed * Time.deltaTime);
            _material.color = color;

            yield return new WaitForSeconds(0.05f);
        }
    }
}
