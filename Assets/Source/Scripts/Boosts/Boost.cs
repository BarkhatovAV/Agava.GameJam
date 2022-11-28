using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    public event Action Taken;

    protected void OnTake()
    {
        Taken?.Invoke();
    }
}
