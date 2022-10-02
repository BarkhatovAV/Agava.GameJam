using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon, IReloadable
{
    [SerializeField] private int _clipSize;
    [SerializeField] private float _reloadTime;

    private BulletsArmory _bullets = new BulletsArmory();
    private int _currentClipAmount;
    private bool _isCanShoot;

    public event Action<float> ReloadStarted;
    public event Action ReloadFinished;

    private void Start()
    {
        _bullets.AddBullets(1000000000);
        _currentClipAmount = _clipSize;
        _isCanShoot = true;
    }

    public override void Fire(RaycastHit hitInfo)
    {
        if ((_isCanShoot == true) && (CheckDelay() == true))
        {
            _currentClipAmount--;
            base.Fire(hitInfo);

            if (CheckNeedReload() == true)
                Reload();
        }
    }

    public void Reload()
    {
        _isCanShoot = false;
        StartCoroutine(OnReload());
        ReloadStarted?.Invoke(_reloadTime);
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
        ReloadFinished?.Invoke();
    }
}
