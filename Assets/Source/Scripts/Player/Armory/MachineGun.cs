using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon, IReloadable
{
    [SerializeField] private int _clipSize;
    public int ClipSize => _clipSize;

    public void Fire(RaycastHit hitInfo)
    {
        if (_isCanShoot == true)
        {
            OnFire();

            if (hitInfo.collider.TryGetComponent(out Ground ground) && _shotDistance > hitInfo.distance)
                print(hitInfo.distance);

            if (CheckNeedReload() == true)
                Reload();
        }
    }

    public void Reload()
    {
        _isCanShoot = false;
        StartCoroutine(OnReload());
    }

    private IEnumerator OnReload()
    {
        yield return new WaitForSeconds(_reloadTime);

        if (_amountAmmo > _clipSize)
            _currentClipAmount = _clipSize;
        else
            _currentClipAmount = _amountAmmo;

        _isCanShoot = true;
    }
}
