using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDamageStatistics : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private TMP_Text _textTime;
    [SerializeField] private TMP_Text _textTotalDamage;
    [SerializeField] private TMP_Text _textDPS;

    private int _totalDamage;
    private string _baseTextTime = "Время: ";
    private string _baseTextTotalDamage = "Общий урон: ";
    private string _baseTextDPS = "Текущий DPS: ";

    private DateTime _timeFromStart = new DateTime();
    private DateTime _emptyTime = new DateTime();
    private TimeSpan _timeSpan;

    private void OnEnable()
    {
        for(int i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].DamageDealed += OnDamageDealed;
        }
    }

    private void Start()
    {
        OnDamageDealed(0);
        StartCoroutine(Timer());
        StartCoroutine(DPSCalculator());
    }

    private void OnDisable()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].DamageDealed -= OnDamageDealed;
        }
    }

    private void OnDamageDealed(int damage)
    {
        IncreaseTotalDamage(damage);
    }

    private void IncreaseTotalDamage(int damage)
    {
        _totalDamage += damage;
        _textTotalDamage.text = _baseTextTotalDamage + _totalDamage.ToString();
    }

    private IEnumerator DPSCalculator()
    {
        while(true)
        {
            _timeSpan = _timeFromStart - _emptyTime;

            _textDPS.text = _baseTextDPS + string.Format("{0:0.##}", _totalDamage / _timeSpan.TotalSeconds);

            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);

            _timeFromStart = _timeFromStart.AddSeconds(1);
            _textTime.text = _baseTextTime + string.Format("{0}:{1:00}", _timeFromStart.Minute, _timeFromStart.Second);
        }
    }
}