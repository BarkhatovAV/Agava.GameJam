using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArmory : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;

    private int _currentWeaponIndex = 1;

    public event Action<int> WeaponChanged;

    public Weapon ChangeWeapon()
    {
        DisplayWeapon();

        if (_currentWeaponIndex + 1 == _weapons.Count)
            _currentWeaponIndex = 0;
        else
            _currentWeaponIndex++;

        WeaponChanged?.Invoke(_currentWeaponIndex);
        DisplayWeapon();

        return _weapons[_currentWeaponIndex];
    }

    public Weapon ChangeWeapon(int value)
    {       
        if (value > 0)
            return ChangeWeapon();

        DisplayWeapon();

        if (_currentWeaponIndex + value >= 0)
            _currentWeaponIndex += value;
        else
            _currentWeaponIndex = _weapons.Count - 1;

        WeaponChanged?.Invoke(_currentWeaponIndex);
        DisplayWeapon();

        return _weapons[_currentWeaponIndex];
    }

    private void DisplayWeapon()
    {
        if (_weapons[_currentWeaponIndex].gameObject.activeSelf == true)
            _weapons[_currentWeaponIndex].gameObject.SetActive(false);
        else
            _weapons[_currentWeaponIndex].gameObject.SetActive(true);
    }
}
