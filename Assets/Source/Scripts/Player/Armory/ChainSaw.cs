using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSaw : Weapon, IWeapon
{
    public void Fire(RaycastHit hitInfo)
    {
        if (hitInfo.collider.TryGetComponent(out Ground ground) && _shotDistance > hitInfo.distance)
            print(hitInfo.distance);
    }
}
