using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            _direction += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            _direction -= Vector3.forward;
        if (Input.GetKey(KeyCode.D))
            _direction += Vector3.right;
        if (Input.GetKey(KeyCode.A))
            _direction -= Vector3.right;

        MoveDirection(_direction);
    }

    private void MoveDirection(Vector3 direction)
    {
        Vector3 normilizedDirection = direction.normalized;
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * normilizedDirection * _speed * Time.deltaTime;

        _rigidbody.velocity =  new Vector3(move.x, _rigidbody.velocity.y, move.z);
    }
}
