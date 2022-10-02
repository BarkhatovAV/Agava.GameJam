using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerKiller : MonoBehaviour
{
    [SerializeField] private Image _imageTopEye;
    [SerializeField] private Image _imageBottomEye;
    [SerializeField] private Image _imageWasted;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private float _closeEyeSpeed;
    [SerializeField] private float _targetSizeImageWasted;

    private float _delayResizeImageWasted = 12;
    
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
        StartCoroutine(OnCloseEye());
        StartCoroutine(OnWastedIncrease());
    }

    private void CloseEye(Image eye)
    {
        eye.rectTransform.position = Vector3.MoveTowards(eye.rectTransform.position, _imageWasted.rectTransform.position, _closeEyeSpeed * Time.deltaTime);
    }

    private void WastedIncrease(float value)
    {
        _imageWasted.rectTransform.sizeDelta += Vector2.one * value;
    }

    private IEnumerator OnCloseEye()
    {
        while(_imageBottomEye.rectTransform.position != Vector3.zero)
        {
            CloseEye(_imageTopEye);
            CloseEye(_imageBottomEye);

            yield return new WaitForSeconds(0.01f);  
        }
    }

    private IEnumerator OnWastedIncrease()
    {
        yield return new WaitForSecondsRealtime(_delayResizeImageWasted);

        while(_imageWasted.rectTransform.sizeDelta.x < _targetSizeImageWasted)
        {
            WastedIncrease(1);

            yield return new WaitForSeconds(0.01f);
        } 
            
    }
}
