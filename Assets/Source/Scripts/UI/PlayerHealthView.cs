using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private SlicedFilledImage _filledImage;
    [SerializeField] private PlayerHealth _playerHealth;

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

    private void Awake()
    {
        _filledImage.fillAmount = 1;
    }

    private void OnHealthChanged(float health)
    {
        _filledImage.fillAmount = Mathf.Lerp(0f, 1f, health / _playerHealth.MaxHealth);
    }
}
