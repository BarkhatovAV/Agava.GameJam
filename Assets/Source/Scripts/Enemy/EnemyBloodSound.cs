using System.Collections;
using UnityEngine;

public class EnemyBloodSound : MonoBehaviour
{
    private readonly float _delayBeforeDestroying = 2f;

    private void Start()
    {
        StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(_delayBeforeDestroying);
        Destroy(gameObject);
    }
}