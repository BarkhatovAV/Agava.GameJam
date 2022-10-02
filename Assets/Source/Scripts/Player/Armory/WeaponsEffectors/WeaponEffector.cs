using System.Collections;
using UnityEngine;

public abstract class WeaponEffector : MonoBehaviour
{
    private Quaternion  _baseLocalRotation;
    private float _timeOnAnimateWeaponMove = 0.5f;
    private float _targetAngelRotationX = 35;
    private Quaternion _targetRotationX;

    private void Start()
    {
        _baseLocalRotation = transform.localRotation;
        _targetRotationX = Quaternion.Euler(_targetAngelRotationX, transform.localRotation.y, transform.localRotation.z);
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
        StartCoroutine(OnReload(reloadTime));
    }

    private IEnumerator OnReload(float reloadTime)
    {
        print(Time.time);
        float coroutineDelay = 0.01f;
        float rotationStep = (_targetAngelRotationX - _baseLocalRotation.x) * coroutineDelay;


        while(transform.localRotation != _targetRotationX)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, _targetRotationX, rotationStep);

            yield return new WaitForSeconds(coroutineDelay);
        }
        print(Time.time);

        float waitingTime = reloadTime - rotationStep * coroutineDelay * 2;

        yield return new WaitForSeconds(waitingTime);
        print(Time.time);

        while (transform.localRotation != _baseLocalRotation)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, _baseLocalRotation, rotationStep);

            yield return new WaitForSeconds(coroutineDelay);
        }
        print(Time.time);
    }
}
