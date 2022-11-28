using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    public event Action<Vector3> Taken;

    protected void OnTake()
    {
        Taken?.Invoke(transform.position);
    }
}
