using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Util
{
    public WeaponOption wo = new WeaponOption(true);
    public Sprite WeaponImage; //������ �̹��� ����
    //�߻��� �Լ�
    protected abstract void LeftAtk();//�ְ���
    protected abstract void RightAtk(float Mp);//��������

    public abstract void LeftAtkUpdate();//�ְ��� ��������
    public abstract void RightAtkUpdate();//�������� ��������

    public abstract void weaponAwake();//���� ������Ʈ
    //���� ���� �ʱ�ȭ
    public virtual void weaponFixedUpdate() {
        GetComponent<SpriteRenderer>().flipX = Gamemanager.player.GetComponent<SpriteRenderer>().flipX;//�÷��̾��� �¿��Ī�� ���⵵ ����
        wo.SkillCool += Time.deltaTime;//��ų������κ��� ���ʰ� �������� ������Ʈ��
    }
    public virtual void weaponUpdate() { 
        LeftAtkUpdate();
        RightAtkUpdate();
    }

    //���ʽ���� Gamemanager�� Player������ �ΰ��ӿ��ִ� ������ ������Ʈ�� ��ġ��Ŵ
    public virtual void Awake()
    {
        weaponAwake();
    }
    protected void ImageUpdate() { 
        this.GetComponent<SpriteRenderer>().sprite = WeaponImage;
    }
}
