using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Util
{
    public StatSetting playerstat;//플레이어의 스텟
    public PlayerMove PlayerMove;//플레이어의 움직임 방식
    public RP playerRP;
    public Weapon weapon;
    public Weapon weapon1;
    public Weapon weapon2;
    public Weapon weapon3;
    public WeaponUse WeaponUse;
    public int UwN = 1;//UseWeaponNumber
    public bool canhit;

    //첨언 : 플레이어의 이동관련 스크립트들은 모두 추상형 클레스 PlayerMove로부터 상속되었다. 이들은 각각 moveUpdate()와 dashUpdate()를 구체화한다.
    
    void Awake()//최초실행시
    {
        playerstat = new StatSetting(true);//플레이어의 스텟 설정을 기본값으로 지정
//        PlayerMove = GetComponent<PlayerMoveMomentNormal>();//플레이어의 움직임 종류를 일반으로 설정
        PlayerMove = GetComponent<PlayerMovementChess>();
        playerRP = new RP(4, 4);//최초실행시 플레이어의 방의 위치는 4,4로 정한다.(4,4에는 로비가 항상 존재)
        canhit = true;
        WeaponUse = this.GetComponent<WeaponUse>();
        
    }

    private void Update()
    {
        //플레이어의 움직임 타입에 맞춰
        
        PlayerMove.moveUpdate();//움직임
        PlayerMove.dashUpdate();//대쉬

        //를 실행
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