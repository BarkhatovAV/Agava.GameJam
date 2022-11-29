using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private TMP_Text _textMaxHealth;
    [SerializeField] private TMP_Text _textCurrentHealth;
    [SerializeField] private PlayerHealth _playerHealth;

    private float _lerpSpeed = 1;
    private Coroutine _coroutine;

    private void OnValidate()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnEnable()
    {
        _playerHealth.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float health, float maxHealth)
    {
         if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangingUIHealth(health / maxHealth));

        _textCurrentHealth.text = health.ToString();
        _textMaxHealth.text = maxHealth.ToString();
    }

    private void ChangeHealth(float targetValue)
    {
        _sliderHealth.value = Mathf.Lerp(_sliderHealth.value, targetValue, _lerpSpeed * Time.deltaTime);
    }

    private IEnumerator ChangingUIHealth(float targetValue)
    {
        while(_sliderHealth.value != targetValue)
        {
            ChangeHealth(targetValue);

            yield return new WaitForSeconds(0.01f);
        }
    }
}
