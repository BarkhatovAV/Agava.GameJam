using UnityEngine;

public interface ITarget
{
    Vector3 CurrentPosition { get; }

    void TryTakeDamage(int damage);
}