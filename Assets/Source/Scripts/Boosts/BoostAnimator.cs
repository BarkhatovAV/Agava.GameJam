using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostAnimator : MonoBehaviour
{
    [SerializeField] private float _speed = 0.8f;
    [SerializeField] private float _rotationSpeed = 50;
    [SerializeField] private float _amplitude = 0.5f;

    private Coroutine _coroutine;
    private Vector3 _topPosition;
    private Vector3 _bottomPosition;


    private void Start()
    {
        _topPosition = new Vector3(transform.position.x, transform.position.y + _amplitude, transform.position.z);
        _bottomPosition = new Vector3(transform.position.x, transform.position.y - _amplitude, transform.position.z);
        StartCoroutine(OnAnimation());
    }

    private IEnumerator OnAnimation()
    {
        Vector3 targetPosition = _topPosition;

       while(true)
       {
            float distance = (targetPosition - transform.position).magnitude;

            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime / distance);
            transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);

            if(transform.position == targetPosition)
            {
                if (targetPosition == _topPosition)
                    targetPosition = _bottomPosition;
                else
                    targetPosition = _topPosition;
            }
       }
    }
}
