using System;
using System.Collections;
using UnityEngine;

public class AssaultRifle : Weapon, IReloadable
{
    [SerializeField] private int _clipSize;
    [SerializeField] private float _reloadTime;

    private BulletsArmory _bullets = new BulletsArmory();
    private int _currentClipAmount;
    private bool _canShoot;

    public event Action<float> ReloadStarted;
    public event Action ReloadFinished;

    private void Awake()
    {
        _bullets.AddBullets(1000000000);
        _currentClipAmount = _clipSize;
        _canShoot = true;
    }

    private void OnEnable()
    {
        if (CheckNeedReload() == true)
            Reload();
    }

    public override void Fire(Collider collider = null)
    {
        if ((_canShoot == true) && (CheckDelay() == true))
        {
            _currentClipAmount--;
            base.Fire(collider);

            if (CheckNeedReload() == true)
                Reload();
        }
    }

    public void Reload()
    {
        _canShoot = false;
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

        _canShoot = true;
        ReloadFinished?.Invoke();
    }
}
