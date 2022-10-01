using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] private WeaponArmory _weaponArmory;
    [SerializeField] private List<WeaponSwitchItem> _weaponSwitchItems;

    private void OnValidate()
    {
        _weaponArmory = FindObjectOfType<WeaponArmory>();
    }

    private void OnEnable()
    {
        _weaponArmory.WeaponChanged += OnWeaponChanged;
    }

    private void OnDisable()
    {
        _weaponArmory.WeaponChanged -= OnWeaponChanged;
    }

    private void OnWeaponChanged(int index)
    {
        for (int i = 0; i < _weaponSwitchItems.Count; i++)
        {
            if (i == index)
                _weaponSwitchItems[i].Activate();
            else
                _weaponSwitchItems[i].Deactivate();
        }
    }
}
