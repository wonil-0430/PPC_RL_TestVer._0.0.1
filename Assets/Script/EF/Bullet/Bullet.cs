using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : EF
{
    public float BulletSpeed = 100;//총알의 속도 기본값은 100으로 지정
    public Camera cm;
    protected Vector3 mouse;
    protected float x;
    protected float y;

    protected override void Awake()
    {
        base.Awake();
        SetDamage();
        cm = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
    public override void SetDamage()
    {
        Damage = gamemanager.GetDamage(critical);
        Debug.Log(Damage);
    }

    protected void BulletMove() {
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x / Mathf.Abs(x)) * (Mathf.Sqrt(Mathf.Pow(BulletSpeed * x, 2) / (Mathf.Pow(x, 2) + Mathf.Pow(y, 2)))),
            (y / Mathf.Abs(y)) * (Mathf.Sqrt(Mathf.Pow(BulletSpeed * y, 2) / (Mathf.Pow(y, 2) + Mathf.Pow(x, 2)))), 0);
    }

    protected void BulletRotation() {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(y, x) * 180 / Mathf.PI);
    }
}
