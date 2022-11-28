using System;
using UnityEngine;

public interface IWeapon 
{
    void Fire(RaycastHit hitinfo);

    event Action Fired;
}
