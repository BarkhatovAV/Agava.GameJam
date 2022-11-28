using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector3 _direction;

    private void OnEnable()
    {
        MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

    private void MoveForward()
    {
        StartCoroutine(OnMove());
    }

    private void Move()
    {
        var target = Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward * _speed;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + target, _speed * Time.deltaTime);

        _direction = transform.position + target - transform.position;
    }

    private IEnumerator OnMove()
    {
        float timeTodeactivate = 5;
        float currentTime = 0;

        while (timeTodeactivate > currentTime)
        {
            currentTime += 0.01f;
            Move();
            yield return new WaitForSeconds(0.01f);
        }

        gameObject.SetActive(false);
    }
}
