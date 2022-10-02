using UnityEngine;

public class Healer : MonoBehaviour
{
    private int _value = 40;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerHealth player))
        {
            player.Heal(_value);
            Destroy(gameObject);
        }
    }
}
