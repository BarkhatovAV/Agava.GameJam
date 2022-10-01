using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon, IReloadable
{
    [SerializeField] private int _clipSize;
    [SerializeField] private float _reloadTime;

    private BulletsArmory _bullets = new BulletsArmory();
    private int _currentClipAmount;
    private bool _isCanShoot;

    public void Fire(RaycastHit hitInfo)
    {
        if (_isCanShoot == true)
        {
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

    public void TakeBullets(int value)
    {
        _bullets.AddBullets(value);
    }

    private bool CheckNeedReload()
    {
        return _currentClipAmount <= 0;
    }

    private IEnumerator OnReload()
    {
        yield return new WaitForSeconds(_reloadTime);

        if (_bullets.Value > _clipSize)
            _currentClipAmount = _clipSize;
        else
            _currentClipAmount = _bullets.Value;

        _isCanShoot = true;
    }
}
