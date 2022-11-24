using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UISliderReloader : MonoBehaviour
{
    [SerializeField] private PlayerSlider _slider;
    [SerializeField] private Image _imageSlider;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _slider.ReloadStarted += OnReloadStarted;
        _slider.ReloadCanceled += OnReloadCanceled;
    }

    private void OnDisable()
    {
        _slider.ReloadStarted -= OnReloadStarted;
        _slider.ReloadCanceled -= OnReloadCanceled;
    }

    private void OnReloadCanceled()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _imageSlider.fillAmount = 1;
    }

    private void OnReloadStarted(float duration)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnSliderReload(duration));
    }

    private IEnumerator OnSliderReload(float duration)
    {
        float step = 0.01f;
        float fillingStepSize = 1f / (duration/step);

        _imageSlider.fillAmount = 0;

        while (_imageSlider.fillAmount != 1)
        {
            _imageSlider.fillAmount += fillingStepSize;
            yield return new WaitForSeconds(step);
        }
    }
}
