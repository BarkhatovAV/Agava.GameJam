using UnityEngine;

public class PlayerHealthView : UIBar
{
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

    private void OnHealthChanged(float currentValue, float maxValue)
    {
        OnValueChanged(currentValue, maxValue);
    }
}
