using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerKiller : MonoBehaviour
{
    [SerializeField] private Image _imageTopEye;
    [SerializeField] private Image _imageBottomEye;
    [SerializeField] private Image _imageTarget;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private float _closeEyeSpeed;


    private void OnValidate()
    {
        _health = FindObjectOfType<PlayerHealth>();
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void OnDied()
    {
        StartCoroutine(OnDiyng());
    }

    private void CloseEye(Image eye)
    {
        eye.rectTransform.position = Vector3.MoveTowards(eye.rectTransform.position, _imageTarget.rectTransform.position, _closeEyeSpeed * Time.deltaTime);
    }

    private IEnumerator OnDiyng()
    {
        print("Start");
        while(_imageBottomEye.rectTransform.position != Vector3.zero)
        {
            CloseEye(_imageTopEye);
            CloseEye(_imageBottomEye);

            yield return new WaitForSeconds(0.01f);  
        }

        print("Finish");
    }
}
