using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitchItem : MonoBehaviour
{
    [SerializeField] private Image _iconBackGround;

    private float _startColorAlpha = 0.6f;
    private float _activeAlpha = 1;
    private Vector3 _startScale = new Vector3(1, 1, 1);
    private Vector3 _activeScale = new Vector3(1.5f, 1.5f, 1.5f);

    public void Activate()
    {
        SetColor(_activeAlpha);
        transform.localScale = _activeScale;
    }

    public void Deactivate()
    {
        SetColor(_startColorAlpha);
        transform.localScale = _startScale;
    }

    private void SetColor(float alpha)
    {
        Color color = new Color(_iconBackGround.color.r, _iconBackGround.color.g, _iconBackGround.color.b, alpha);
        _iconBackGround.color = color;
    }
}
