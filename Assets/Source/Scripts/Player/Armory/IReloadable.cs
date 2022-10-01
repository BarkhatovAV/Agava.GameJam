using UnityEngine;
public interface IReloadable : IWeapon
{
    int ClipSize { get; }
    void Reload();
}
