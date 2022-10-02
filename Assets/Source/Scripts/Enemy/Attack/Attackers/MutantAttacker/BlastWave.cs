using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BlastWave : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private int _damage;
    [Min(0)]
    [SerializeField] private float _targetRadius;

    private readonly float _secondsBeforeDestroy = 0.2f;

    private SphereCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ITarget target))
        {
            target.Apply(_damage);
            Destroy(gameObject);
        }
    }

    public IEnumerator Explode(float delay)
    {
        yield return new WaitForSeconds(delay);
        _collider.enabled = true;
        _collider.radius = _targetRadius;
        yield return new WaitForSeconds(_secondsBeforeDestroy);
        Destroy(gameObject);
    }
}