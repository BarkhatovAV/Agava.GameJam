using UnityEngine;

public class PlayerViewRotator : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private Camera _playerCamera;

    private float _verticalAxis;
    private float _horizontalAxis;
    private float _verticalLimit = 75;

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        _verticalAxis += Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;
        _horizontalAxis += Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;

        _verticalAxis = ClampVerticalView(_verticalAxis);

        transform.rotation = Quaternion.Euler(0 , _horizontalAxis, 0);
        _playerCamera.transform.localRotation = Quaternion.Euler(-_verticalAxis, 0, 0);

    }

    private float ClampVerticalView(float value)
    {
        return Mathf.Clamp(value, -_verticalLimit, _verticalLimit);
    }
}
