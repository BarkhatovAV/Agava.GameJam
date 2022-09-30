using UnityEngine;

public class PlayerViewRotator : MonoBehaviour
{
    [SerializeField] private float _sensitivity;

    private float _verticalAxis;
    private float _horizontalAxis;
    private float _verticalLimit = 90;

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        _verticalAxis += Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;
        _horizontalAxis += Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        _verticalAxis = ClampVerticalView(_verticalAxis);

        transform.rotation = Quaternion.Euler(-_verticalAxis, _horizontalAxis, 0);
    }

    private float ClampVerticalView(float value)
    {
        return Mathf.Clamp(value, -_verticalLimit, _verticalLimit);
    }
}
