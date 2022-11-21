using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _slidePower;
    [SerializeField] private float _sliderReloadTime;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private bool _canSlide;
    private float _stepSize = 0.01f;

    public event Action<float> SlideReloadStarted;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _canSlide = true;
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && _canSlide == true)
            StartCoroutine(OnSlide(_direction));

        MoveDirection(_direction);
    }

    private void MoveDirection(Vector3 direction)
    {
        Vector3 normilizedDirection = direction.normalized;
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * normilizedDirection * _speed * Time.deltaTime;

        _rigidbody.velocity =  new Vector3(move.x, _rigidbody.velocity.y, move.z);
    }

    private void Slide(Vector3 direction)
    {
        Vector3 normilizedDirection = direction.normalized;
        Vector3 moveDirection = Quaternion.Euler(0, transform.eulerAngles.y, 0) * normilizedDirection;

        _rigidbody.AddForce(moveDirection * _slidePower, ForceMode.Acceleration);
    }

    private IEnumerator OnSlide(Vector3 direction)
    {
        _canSlide = false;

        float duration = 0.3f;
        int stepCount = (int)(duration / _stepSize);

        StartCoroutine(OnReloadSlide());

        for(int i = 0; i < stepCount; i++)
        {
            Slide(direction);
            yield return new WaitForSeconds(_stepSize);
        }
    }

    private IEnumerator OnReloadSlide()
    {
        SlideReloadStarted?.Invoke(_sliderReloadTime);
        yield return new WaitForSeconds(_sliderReloadTime);
        _canSlide = true;
    }
}
