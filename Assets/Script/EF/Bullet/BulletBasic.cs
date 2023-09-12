using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : Bullet
{
    protected override void Awake()
    {
        base.Awake();
        transform.position = transform.GetComponentInParent<Transform>().position;//�Ѿ��� �������� �̵�

        mouse = cm.ScreenToWorldPoint(Input.mousePosition);//���콺�� ��ġ ������Ʈ
        x = mouse.x - transform.position.x;//���콺�� �Ѿ��� x�Ÿ�
        y = mouse.y - transform.position.y;//���콺�� �Ѿ��� y�Ÿ�
        BulletMove();//�Ѿ��̵�
        BulletRotation();//�Ѿ� ȸ��
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
