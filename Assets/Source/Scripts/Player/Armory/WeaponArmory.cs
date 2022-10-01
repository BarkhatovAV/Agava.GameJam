using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArmory : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;

    private int _currentWeaponIndex;

    public Weapon ChangeWeapon()
    {
        DisplayWeapon();

        if (_currentWeaponIndex + 1 == _weapons.Count)
            _currentWeaponIndex = 0;
        else
            _currentWeaponIndex++;

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

    private void AddBullets()
    {

    }

    private void ShootBullets()
    {

    }
}
