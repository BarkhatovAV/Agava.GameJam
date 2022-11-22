using System.Collections;
using UnityEngine;

public class EnemyBurnStarter : MonoBehaviour
{
    [SerializeField] private float _burnigSeconds;
    [SerializeField] private ParticleSystem _particleFire;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _particleFire.Stop();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FlameThrower flameThrower))
            StartBurn();
    }

    private void StartBurn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Burn());
    }

    private IEnumerator Burn()
    {
        _particleFire.Play();
        yield return new WaitForSeconds(_burnigSeconds);
        _particleFire.Stop();
    }

}
