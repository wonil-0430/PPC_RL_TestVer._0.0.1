using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EF : Util
{
    public float Damage;
    public bool critical = false;
    protected virtual void Awake()
    {
        critical = gamemanager.GetCritical();
    }

    public abstract void SetDamage();
}
