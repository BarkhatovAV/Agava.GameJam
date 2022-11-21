using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UISliderReloader : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private Image _imageSlider;

    private void OnEnable()
    {
        _movement.SlideReloadStarted += OnSliderReloadStarted;
    }

    private void OnDisable()
    {
        _movement.SlideReloadStarted -= OnSliderReloadStarted;
    }

    private void OnSliderReloadStarted(float duration)
    {
        StartCoroutine(OnSliderReload(duration));
    }

    private IEnumerator OnSliderReload(float duration)
    {
        float step = 0.01f;
        float fillingStepSize = 1 / (duration/step);
        _imageSlider.fillAmount = 0;

        while(_imageSlider.fillAmount != 1)
        {
            _imageSlider.fillAmount += fillingStepSize;
            yield return new WaitForSeconds(step);
        }
    }
}
