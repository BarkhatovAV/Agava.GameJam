using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCurrentValue;
    [SerializeField] private TMP_Text _textMaxValue;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _lerpSpeed;

    private Coroutine _coroutine;

    protected void OnValueChanged(float currentValue, float maxValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnChanging(currentValue / maxValue));

        _textCurrentValue.text = currentValue.ToString();
        _textMaxValue.text = maxValue.ToString();
    }

    private void ChangeValue(float targetValue)
    {
        _slider.value = Mathf.Lerp(_slider.value, targetValue, _lerpSpeed * Time.deltaTime);
    }

    private IEnumerator OnChanging(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            ChangeValue(targetValue);

            yield return new WaitForSeconds(0.01f);
        }
    }
}
