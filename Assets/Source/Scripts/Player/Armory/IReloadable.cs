using System;
using UnityEngine;
public interface IReloadable : IWeapon
{
    event Action<float> ReloadStarted;
    event Action ReloadFinished;

    void Reload();
}
