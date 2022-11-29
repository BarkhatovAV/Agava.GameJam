using System;
using UnityEngine;

public interface IWeapon 
{
    void Fire(Collider collider = null);

    event Action Fired;
}
