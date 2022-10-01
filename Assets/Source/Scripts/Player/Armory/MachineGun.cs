using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon, IReloadable
{
    private int _clipSize;
    public int ClipSize => _clipSize;

    public void Reload(float reloadTime)
    {
        throw new System.NotImplementedException();
    }
}
