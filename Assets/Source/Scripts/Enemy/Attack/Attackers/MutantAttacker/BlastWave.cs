using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BlastWave : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private int _damage;
    [Min(0)]
    [SerializeField] private float _targetRadius;
    [Min(0)]
    [SerializeField] private float _speed;

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

        while (_collider.radius != _targetRadius)
        {
            _collider.radius = Mathf.Lerp(_collider.radius, _targetRadius, _speed * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
    }
}