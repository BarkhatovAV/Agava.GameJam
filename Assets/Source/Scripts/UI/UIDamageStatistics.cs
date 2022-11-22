using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDamageStatistics : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private TMP_Text _textTotalDamage;
    [SerializeField] private TMP_Text _textCurrentDPM;
    [SerializeField] private TMP_Text _textMaxDPM;

    private int _totalDamage;
    private int _maxDPM;
    private Dictionary<float, int> _timeDamage = new Dictionary<float, int>();
    private List<float> _removeKeys = new List<float>();

    private string _baseTextTotalDamage = "Общий урон: ";
    private string _baseTextCurrentDPM = "Текущий DPM: ";
    private string _baseTextMaxDPM = "Максимальный DPM: ";

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
        StartCoroutine(CalculateDPM());
        _textMaxDPM.text = _baseTextMaxDPM +  _maxDPM.ToString();
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
        AddInDPM(damage);
        TotalDamageCalculator(damage);
    }

    private void TotalDamageCalculator(int damage)
    {
        _totalDamage += damage;
        _textTotalDamage.text = _baseTextTotalDamage + _totalDamage.ToString();
    }

    private void AddInDPM(int damage)
    {
        _timeDamage.Add(Time.time, damage);
    }

    private void RemoveExpiredTimeKeys()
    {
        for (int i = 0; i < _removeKeys.Count; i++)
        {
            _timeDamage.Remove(_removeKeys[i]);
        }

        _removeKeys = new List<float>();
    }

    private IEnumerator CalculateDPM()
    {
        while(true)
        {
            int accumulatedValue = 0;

            foreach (float time in _timeDamage.Keys)
            {
                if (time < (Time.time - 60))
                    _removeKeys.Add(time);
                else
                    accumulatedValue += _timeDamage[time];
            }

            RemoveExpiredTimeKeys();

            _textCurrentDPM.text = _baseTextCurrentDPM +  accumulatedValue.ToString();

            if(accumulatedValue > _maxDPM)
            {
                _maxDPM = accumulatedValue;
                _textMaxDPM.text = _baseTextMaxDPM +  _maxDPM.ToString();
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
