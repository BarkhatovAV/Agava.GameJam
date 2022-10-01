using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private WeaponArmory _armory;
    [SerializeField] private Weapon _startWeapon;

    private Weapon _currentWeapon;

    private void OnValidate()
    {
        _armory = FindObjectOfType<WeaponArmory>();
    }

    private void Start()
    {
        _currentWeapon = _startWeapon;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            Fire();
    }

    private void ChangeWeapon()
    {
        _currentWeapon = _armory.ChangeWeapon();
    }

    private void Fire()
    {
        _currentWeapon.Fire();
    }
}
