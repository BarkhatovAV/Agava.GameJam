using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private bool _isGround;
    private bool _isDoubleJumpAllow;
    private float _velocityYLimit = 10;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            TryJump();

        ClampVelocityY();
    }

    private void ClampVelocityY()
    {
        Vector3 velocity = _rigidbody.velocity;
        velocity.y = Mathf.Clamp(velocity.y, -_velocityYLimit, _velocityYLimit);
        _rigidbody.velocity = velocity;
    }

    private void TryJump()
    {
        if (_isGround == true)
        {
            Jump();
            _isGround = false;
        }
        else if(_isDoubleJumpAllow == true)
        {
            Jump();
            _isDoubleJumpAllow = false;
        }

    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Ground ground))
        {
            _isGround = true;
            _isDoubleJumpAllow = true;
        }
    }
}
