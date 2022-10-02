using System.Collections;
using UnityEngine;

public abstract class WeaponEffector : MonoBehaviour
{
    private Quaternion _baseRotation;
    private float _timeOnAnimateWeaponMove = 0.5f;
    private float _targetAngelRotationX;

    private void Start()
    {
        _baseRotation = transform.rotation;
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
        float coroutineDelay = 0.01f;
        float rotationStep = (transform.rotation.x - _targetAngelRotationX) / _timeOnAnimateWeaponMove * coroutineDelay;

        while(transform.rotation.x != _targetAngelRotationX)
        {
            Quaternion rotation = transform.rotation;
            rotation.x = Mathf.MoveTowards(rotation.x, _targetAngelRotationX, rotationStep);
            transform.rotation = rotation;

            yield return new WaitForSeconds(coroutineDelay);
        }

        yield return new WaitForSeconds(reloadTime - _timeOnAnimateWeaponMove * 2);

        while (transform.rotation.x != _baseRotation.x)
        {
            Quaternion rotation = transform.rotation;
            rotation.x = Mathf.MoveTowards(rotation.x, _baseRotation.x, rotationStep);
            transform.rotation = rotation;

            yield return new WaitForSeconds(coroutineDelay);
        }
    }
}
