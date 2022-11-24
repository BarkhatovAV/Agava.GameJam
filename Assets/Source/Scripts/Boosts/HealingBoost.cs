using UnityEngine;

public class HealingBoost : MonoBehaviour
{
    [SerializeField] private int _value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth player))
        {
            player.Heal(_value);
            Destroy(gameObject);
        }
    }
}
