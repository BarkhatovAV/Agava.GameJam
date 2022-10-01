using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _clipSize;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _shotDistance;
    [SerializeField] private float _delayBetweenShots;

    private bool _isCanShoot = true;
    private int _currentClipAmount;
    private int _amountAmmo;

    public void Fire(RaycastHit hitInfo)
    {
        if(_isCanShoot == true)
        {
            _currentClipAmount--;
            _amountAmmo--;
            
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

    private bool CheckNeedReload()
    {
        return _currentClipAmount == 0;
    }

    private IEnumerator OnReload()
    {
        yield return new WaitForSeconds(_reloadTime);

        if(_amountAmmo > _clipSize)
            _currentClipAmount = _clipSize;
        else
            _currentClipAmount = _amountAmmo;

        _isCanShoot = true;
    }
}
