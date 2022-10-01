using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            MoveDirection(Vector3.forward);
        if (Input.GetKey(KeyCode.S))
            MoveDirection(-Vector3.forward);
        if(Input.GetKey(KeyCode.D))
            MoveDirection(Vector3.right);
        if(Input.GetKey(KeyCode.A))
            MoveDirection(-Vector3.right);
    }

    private void MoveDirection(Vector3 direction)
    {
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * direction;

        transform.position += move * _speed * Time.deltaTime;
    }
}
