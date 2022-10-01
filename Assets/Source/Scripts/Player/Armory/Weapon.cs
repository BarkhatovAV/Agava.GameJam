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
    [SerializeField] private ParticleSystem _particleSystem;

    private bool _isCanShoot = true;
    private int _currentClipAmount;
    private int _amountAmmo;

    private void Awake()
    {
        _particleSystem.Stop();
    }
    
    public void AddAmmo(int value)
    {
        _amountAmmo += value;
    }

    public void Fire(RaycastHit hitInfo)
    {
        if(_isCanShoot == true)
        {
            OnFire();
            
            if (hitInfo.collider.TryGetComponent(out Ground ground) && _shotDistance > hitInfo.distance)
                print(hitInfo.distance);

            if (CheckNeedReload() == true)
                Reload();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _particleSystem.Play();
        if (Input.GetMouseButtonUp(0))
            _particleSystem.Stop();
    }

    public void Reload()
    {
        _isCanShoot = false;
        StartCoroutine(OnReload());
    }

    private void OnFire()
    {
        _currentClipAmount--;
        _amountAmmo--;
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
