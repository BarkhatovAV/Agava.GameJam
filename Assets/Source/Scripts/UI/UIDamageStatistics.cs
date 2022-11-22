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

    private IEnumerator DPMCalculator()
    {
        while(true)
        {
            int accumulatedValue = 0;

            foreach (float time in _timeDamage.Keys)
            {
                if (time < (Time.time - 1))
                    _timeDamage.Remove(time);
                else
                    accumulatedValue += _timeDamage[time];
            }

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
