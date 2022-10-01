using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _clipSize;
    [SerializeField] private bool _isMelee;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _meleeDistance;

    private bool _isCanShoot;
    private int _currentClipAmount;
    private float _shotDistance = 1000;
    

    private void Awake()
    {
        if (_isMelee == true)
            _shotDistance = _meleeDistance;
    }

    public void Fire()
    {
        if(_isCanShoot == true)
        {
            RaycastHit hitInfo;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hitInfo, _shotDistance))
                if (hitInfo.collider.TryGetComponent(out Ground ground))
                    print("Shot ground");
        }
    }

    public void Reload()
    {
        StartCoroutine(OnReload());
    }

    private IEnumerator OnReload()
    {
        yield return new WaitForSeconds(_reloadTime);
        _currentClipAmount = _clipSize;
    }
}
