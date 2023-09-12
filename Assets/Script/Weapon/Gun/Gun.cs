using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : Weapon//������� ���� ����鿡 ���Ͽ� ������ ��ũ��Ʈ
{
    public int BulletCount;//���� �Ѿ˼�
    public int BulletMax;//�ִ� ��ź��
    protected float Rtime;//�������� �ɸ��� �ð�
    public GameObject Bullet;//�ش� ���Ⱑ ����� �Ѿ�

    public override void RightAtkUpdate() {
        if (Input.GetMouseButtonDown(1)) {
            RightAtk(wo.SkillMana);
        }
    }

    public override void LeftAtkUpdate()
    {
        if (Input.GetMouseButton(0)&& BulletCount >= 1 && wo.LatkCool >= wo.LatkCoolDown)
        {
            LeftAtk();
        }
    }
    public void ReloadUpdate() {
        if (Input.GetKeyDown(Gamemanager.KeySet.WI)) {
            Reload();
        }
    }
    public void Reload() {//������ �Լ�
        StartCoroutine(wait(Rtime));
    }
    public override void weaponUpdate()
    {
        base.weaponUpdate();
        ReloadUpdate();
    }



    public override void weaponFixedUpdate()
    {
        base.weaponFixedUpdate();
        wo.LatkCool += Time.deltaTime;
    }


    private IEnumerator wait(float time) { //������ �ڷ�ƾ �ڵ�
        yield return new WaitForSeconds(time);//time�� �ð����� �Ʒ��� �ڵ带 ����
        BulletCount = BulletMax;
    }
}
