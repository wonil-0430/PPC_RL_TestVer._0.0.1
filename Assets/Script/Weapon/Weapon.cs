using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Util
{
    public WeaponOption wo = new WeaponOption(true);
    public Sprite WeaponImage; //무기의 이미지 파일
    //추상형 함수
    protected abstract void LeftAtk();//주공격
    protected abstract void RightAtk(float Mp);//보조공격

    public abstract void LeftAtkUpdate();//주공격 시행조건
    public abstract void RightAtkUpdate();//보조공격 시행조건

    public abstract void weaponAwake();//무기 업데이트
    //무기 스텟 초기화
    public virtual void weaponFixedUpdate() {
        GetComponent<SpriteRenderer>().flipX = Gamemanager.player.GetComponent<SpriteRenderer>().flipX;//플레이어의 좌우대칭을 무기도 따라감
        wo.SkillCool += Time.deltaTime;//스킬사용으로부터 몇초가 지났는지 업데이트함
    }
    public virtual void weaponUpdate() { 
        LeftAtkUpdate();
        RightAtkUpdate();
    }

    //최초실행시 Gamemanager와 Player변수를 인게임에있는 각각의 오브젝트에 매치시킴
    public virtual void Awake()
    {
        weaponAwake();
    }
    protected void ImageUpdate() { 
        this.GetComponent<SpriteRenderer>().sprite = WeaponImage;
    }
}
