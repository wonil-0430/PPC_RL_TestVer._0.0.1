using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : Bullet
{
    protected override void Awake()
    {
        base.Awake();
        transform.position = transform.GetComponentInParent<Transform>().position;//총알을 총쪽으로 이동

        mouse = cm.ScreenToWorldPoint(Input.mousePosition);//마우스의 위치 업데이트
        x = mouse.x - transform.position.x;//마우스와 총알의 x거리
        y = mouse.y - transform.position.y;//마우스와 총알의 y거리
        BulletMove();//총알이동
        BulletRotation();//총알 회전
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "mob")
        {
            collision.gameObject.GetComponent<Mob>().getdamage(Damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "door") {
            Destroy(gameObject);
        }
    }
    public float getbulletdamage()
    {
        return Damage;
    } 
}
