using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public Sprite Frame0;
    public Sprite Frame1;
    public AudioSource firesound;
    public override void weaponAwake()
    {
        BulletCount = 15;
        BulletMax = 15;
        Rtime = 2.3f;

        wo.atk = 15;
        wo.LatkCool = 0.1f;
        wo.LatkCoolDown = 0.1f;
        wo.critical = 10f;
        wo.critical_damage = 0f;
        wo.SkillCool = 20f;
        wo.SkillCoolDown = 20f;
        ImageUpdate();
        firesound = this.GetComponent<AudioSource>();
    }

    protected override void LeftAtk()
    {
        if (BulletCount >= 1)
        {

            BulletCount -= 1;
            wo.LatkCool = 0;
            int k;
            if (this.GetComponent<SpriteRenderer>().flipX)
            {
                k = -1;
            }
            else {
                k = 1;
            }
            this.GetComponent<SpriteRenderer>().sprite = Frame1;
            firesound.Play();
            Instantiate(Bullet, Gamemanager.player.transform).transform.position += new Vector3(k * 8, 0, 0);
            StartCoroutine("LftAni");
        }
    }

    protected override void RightAtk(float Mp)
    {
        if (wo.SkillCool >= wo.SkillCoolDown)
        {
            wo.critical = 100f;
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
        wo.critical = 10f;
    }

    private IEnumerator LftAni() {
        yield return new WaitForSeconds(0.05f);
        this.GetComponent<SpriteRenderer>().sprite = Frame0;
    }
}
