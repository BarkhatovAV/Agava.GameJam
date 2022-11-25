using UnityEngine;

public class HealingBoost : Boost
{
    [SerializeField] private int _value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth player))
        {
            player.Heal(_value);
            gameObject.SetActive(false);
        }
    }
}
