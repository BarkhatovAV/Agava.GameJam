using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : Weapon, IWeapon
{
    private BulletsArmory _bullets = new BulletsArmory();

    private void Start()
    {
        _bullets.AddBullets(100000);
    }

    public override void Fire(RaycastHit hitInfo)
    {
        if(_bullets.Value > 0)
        {
            _bullets.ShotBullet();
            base.Fire(hitInfo);
        }
    }

    public void TakeBullets(int value)
    {
        _bullets.AddBullets(value);
    }
}
