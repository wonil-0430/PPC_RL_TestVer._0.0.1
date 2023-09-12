using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1 : Gun
{
    public override void weaponAwake()
    {   
        BulletCount = 15;
        BulletMax = 15;

        Rtime = 5f;
        /*
        atk = 30;
        LatkCool = 0.5f;
        LatkCoolDown = 0.5f;
        
        critical = 30f;
        critical_damage = 0.2f;
        SkillMana = 10f;
        SkillCool = 30f;
        SkillCoolDown = 30f;
        */
        wo.atk = 30;
        wo.LatkCool = 0.5f;
        wo.LatkCoolDown = 0.5f;
        wo.critical = 30f;
        wo.critical_damage = 0.2f;
        wo.SkillMana = 10f;
        wo.SkillCool = 30f;
        wo.SkillCoolDown = 30f;
        ImageUpdate();
    }

    protected override void LeftAtk()
    {
        BulletCount -= 1;
        wo.LatkCool = 0;
        int k;
        if (this.GetComponent<SpriteRenderer>().flipX)
        {
            k = -1;
        }
        else
        {
            k = 1;
        }
        Instantiate(Bullet, Gamemanager.player.transform).transform.position += new Vector3(k * 10, 0, 0);
    }
    protected override void RightAtk(float Mp)
    {
        if (wo.SkillCool >= wo.SkillCoolDown)
        {
            wo.LatkCoolDown = 0.05f;
            wo.SkillCool = 0;
            StartCoroutine(RltS());
        }
        else
        {
            Debug.Log("남은시간");
            Debug.Log(wo.SkillCoolDown - wo.SkillCool);
        }
    }
    private IEnumerator RltS()
    {
        yield return new WaitForSeconds(3f);
        wo.LatkCoolDown = 0.5f;
    }
}
