using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : Util
{
    public float hp;//체력
    public float df = 1;//방어력
    public float Str;



    protected virtual void die() {
        transform.parent.GetComponent<mobChessRoom>().mobcount -= 1;
        Destroy(gameObject);
    }

    public void MobSet(float hp, float str) {
        this.hp = hp;
        this.Str = str;
    }

    protected virtual void Awake()
    {
    }
    public void getdamage(float damage) {
        if (df == 0)
        {
            hp -= damage;
        }
        else { 
            hp -= damage*(Mathf.Sqrt(9 * df / 80000));
        }
    }

    protected void FixedUpdate()
    {
        if (hp <= 0)
        {
            die();
        }
    }
}
