using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArmory : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;

    private int _currentWeaponIndex;

    public Weapon ChangeWeapon()
    {
        if (_currentWeaponIndex + 1 == _weapons.Count)
            _currentWeaponIndex = 0;
        else
            _currentWeaponIndex++;

        return _weapons[_currentWeaponIndex];
    }

    private void AddBullets()
    {

    }

    private void ShootBullets()
    {

    }
}
