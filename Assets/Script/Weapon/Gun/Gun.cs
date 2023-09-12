using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : Weapon//무기들중 총형 무기들에 관하여 정의한 스크립트
{
    public int BulletCount;//현재 총알수
    public int BulletMax;//최대 장탄수
    protected float Rtime;//재장전에 걸리는 시간
    public GameObject Bullet;//해당 무기가 사용할 총알

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
    public void Reload() {//재장전 함수
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


    private IEnumerator wait(float time) { //재장전 코루틴 코드
        yield return new WaitForSeconds(time);//time의 시간이후 아래의 코드를 실행
        BulletCount = BulletMax;
    }
}
