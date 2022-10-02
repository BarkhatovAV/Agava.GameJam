using System.Collections;
using UnityEngine;

public abstract class WeaponEffector : MonoBehaviour
{
    private Quaternion  _baseLocalRotation;
    private float _targetAngelRotationX = 15;
    private Quaternion _targetRotationX;

    private Coroutine _coroutineReload;
    private Coroutine _coroutineShotRecoil;
    private float _recoilDistance = 0.05f;
    private float _recoilSpeed = 10;

    private void Start()
    {
        _baseLocalRotation = transform.localRotation;
        _targetRotationX = Quaternion.Euler(_targetAngelRotationX, transform.localRotation.y, transform.localRotation.z);
    }

    private void OnEnable()
    {
        StopPlayEffects();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartPlayEffects();
        if (Input.GetMouseButtonUp(0))
            StopPlayEffects();
    }

    protected abstract void StopPlayEffects();
    protected abstract void StartPlayEffects();

    protected void Reload(float reloadTime)
    {
        if (_coroutineReload != null)
            StopCoroutine(_coroutineReload);

        _coroutineReload = StartCoroutine(OnReload(reloadTime));
    }

    protected void StartAnimateShotRecoil()
    {
        if (_coroutineShotRecoil != null)
            StopCoroutine(_coroutineShotRecoil);

        _coroutineShotRecoil = StartCoroutine(OnRecoil());
    }

    protected void StoptAnimateShotRecoil()
    {
        if (_coroutineShotRecoil != null)
            StopCoroutine(_coroutineShotRecoil);
    }

    private void RecoilMove(Vector3 target)
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, _recoilSpeed * Time.deltaTime);
    }

    private Vector3 GetRecoilTarget(float targetZ)
    {
        return new Vector3(transform.localPosition.x, transform.localPosition.y, targetZ);
    }

    private IEnumerator OnReload(float reloadTime)
    {
        float coroutineDelay = 0.01f;
        float rotationStep = (_targetAngelRotationX - _baseLocalRotation.x) * coroutineDelay;


        while(transform.localRotation != _targetRotationX)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, _targetRotationX, rotationStep);

            yield return new WaitForSeconds(coroutineDelay);
        }

        float waitingTime = reloadTime - rotationStep * coroutineDelay * 2;

        yield return new WaitForSeconds(waitingTime);

        while (transform.localRotation != _baseLocalRotation)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, _baseLocalRotation, rotationStep);

            yield return new WaitForSeconds(coroutineDelay);
        }
    }

    private IEnumerator OnRecoil()
    {
        float targetZMin = transform.localPosition.z - _recoilDistance;
        float targetZMax = transform.localPosition.z + _recoilDistance;
        Vector3 target = GetRecoilTarget(targetZMin);
        
        while(true)
        {
            RecoilMove(target);

            if (transform.localPosition == target)
                if (target.z == targetZMax)
                    target = GetRecoilTarget(targetZMin);
                else
                    target = GetRecoilTarget(targetZMax);
        

            yield return new WaitForSeconds(0.01f);
        }
    }
}
