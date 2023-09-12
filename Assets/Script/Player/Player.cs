using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Util
{
    public StatSetting playerstat;//�÷��̾��� ����
    public PlayerMove PlayerMove;//�÷��̾��� ������ ���
    public RP playerRP;
    public Weapon weapon;
    public Weapon weapon1;
    public Weapon weapon2;
    public Weapon weapon3;
    public WeaponUse WeaponUse;
    public int UwN = 1;//UseWeaponNumber
    public bool canhit;

    //÷�� : �÷��̾��� �̵����� ��ũ��Ʈ���� ��� �߻��� Ŭ���� PlayerMove�κ��� ��ӵǾ���. �̵��� ���� moveUpdate()�� dashUpdate()�� ��üȭ�Ѵ�.
    
    void Awake()//���ʽ����
    {
        playerstat = new StatSetting(true);//�÷��̾��� ���� ������ �⺻������ ����
//        PlayerMove = GetComponent<PlayerMoveMomentNormal>();//�÷��̾��� ������ ������ �Ϲ����� ����
        PlayerMove = GetComponent<PlayerMovementChess>();
        playerRP = new RP(4, 4);//���ʽ���� �÷��̾��� ���� ��ġ�� 4,4�� ���Ѵ�.(4,4���� �κ� �׻� ����)
        canhit = true;
        WeaponUse = this.GetComponent<WeaponUse>();
        
    }

    private void Update()
    {
        //�÷��̾��� ������ Ÿ�Կ� ����
        
        PlayerMove.moveUpdate();//������
        PlayerMove.dashUpdate();//�뽬

        //�� ����
        weapon.weaponUpdate();
        canhitUpdate();
        
        WeaponUse.WeaponSwap();
        WeaponUse.WeaponSwapUpdate();
    }

    private void FixedUpdate()
    {
        weapon.weaponFixedUpdate();
    }

    public void getdamage(float damage)
    {
        if (canhit)
        {
            if (playerstat.df == 0)
            {
                playerstat.hp -= damage;
            }
            else
            {
                playerstat.hp -= damage * (Mathf.Sqrt(9 * playerstat.df / 80000));
            }
        }
    }
    private void canhitUpdate() {
        if (canhit)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
}