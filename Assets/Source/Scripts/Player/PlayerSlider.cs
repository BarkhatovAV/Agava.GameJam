using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerSlider : MonoBehaviour
{
    [SerializeField] private float _slidePower;
    [SerializeField] private float _sliderReloadTime;
    [SerializeField] private GameObject _visualSlideBoost;

    private Rigidbody _rigidbody;
    private Coroutine _coroutineSlide;
    private Coroutine _coroutineBoost;
    private Coroutine _coroutineReload;
    private bool _canSlide;
    private bool _isBoosted;
    private float _stepSize = 0.01f;

    public event Action<float> ReloadStarted;
    public event Action ReloadCanceled;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _canSlide = true;
    }

    public void TryUse(Vector3 direction)
    {
        if (_canSlide == true)
            StartSlide(direction);
    }

    public void TakeBoost(float duration)
    {
        if (_coroutineBoost != null)
            StopCoroutine(_coroutineBoost);

        _coroutineBoost = StartCoroutine(OnBoosted(duration));
        _canSlide = true;

        if(_coroutineReload != null)
            StopCoroutine(_coroutineReload);

        ReloadCanceled?.Invoke();
    }

    private void StartSlide(Vector3 direction)
    {
        if (_coroutineSlide == null)
            _coroutineSlide = StartCoroutine(OnSlide(direction));
    }

    private void Slide(Vector3 direction)
    {
        Vector3 normilizedDirection = direction.normalized;
        Vector3 moveDirection = Quaternion.Euler(0, transform.eulerAngles.y, 0) * normilizedDirection;

        _rigidbody.AddForce(moveDirection * _slidePower, ForceMode.Acceleration);
    }

    private void StartReload()
    {
        if (_coroutineReload != null)
            StopCoroutine(_coroutineReload);

        _coroutineReload = StartCoroutine(OnReloadSlide());
    }

    private IEnumerator OnBoosted(float duration)
    {
        _isBoosted = true;
        _visualSlideBoost.SetActive(true);
        yield return new WaitForSeconds(duration);
        _visualSlideBoost.SetActive(false);
        _isBoosted = false;
    }

    private IEnumerator OnSlide(Vector3 direction)
    {
        float duration = 0.2f;
        int stepCount = (int)(duration / _stepSize);

        if(_isBoosted == false)
        {
            StartReload();
            _canSlide = false;
        }

        for (int i = 0; i < stepCount; i++)
        {
            Slide(direction);
            yield return new WaitForSeconds(_stepSize);
        }

        _coroutineSlide = null;
    }

    private IEnumerator OnReloadSlide()
    {
        ReloadStarted?.Invoke(_sliderReloadTime);

        float time = 0;

        while (time < _sliderReloadTime)
        {
            time += _stepSize;
            yield return new WaitForSeconds(_stepSize);
        }

        _canSlide = true;
    }
}
