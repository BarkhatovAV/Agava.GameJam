using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerSlider _slider;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private Vector3 _directionVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _slider.TryUse(_direction);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        _directionVelocity = transform.TransformDirection(_direction) * _speed * Time.deltaTime;

        Vector3 velocityChange = (_directionVelocity - _rigidbody.velocity);
        velocityChange.y = 0;

        _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MoveSlower slower))
            _speed *= 0.5f;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out MoveSlower slower))
            _speed *= 2f;
    }
}
