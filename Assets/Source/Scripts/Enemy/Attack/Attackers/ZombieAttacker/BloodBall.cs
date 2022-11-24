using System.Collections;
using UnityEngine;

public class BloodBall : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private int _damage;
    [Min(0)]
    [SerializeField] private float _speed;

    private int _currentWaypointIndex = 0;
    private Vector3 _targetPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ITarget target))
            target.TryTakeDamage(_damage);
    }

    public IEnumerator Move(Vector3[] path)
    {
        while (_currentWaypointIndex < path.Length)
        {
            _targetPosition = path[_currentWaypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            transform.LookAt(_targetPosition);

            if (transform.position == _targetPosition)
                _currentWaypointIndex++;

            yield return null;
        }

        Destroy(gameObject);
    }
}