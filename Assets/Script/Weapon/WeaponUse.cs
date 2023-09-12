using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUse : Util
{
    public GameObject w1;
    public GameObject w2;

    private void Awake()
    {
        gamemanager.Cheek();
    }

    public void WeaponSwap() {
        if (Input.GetKeyDown(Gamemanager.KeySet.Wp1) || Input.GetKeyDown(Gamemanager.KeySet.Wp2))
        {
            if (Gamemanager.playerScript.weapon.wo.SkillCool >= Gamemanager.playerScript.weapon.wo.SkillCoolDown)
            {
                if (Input.GetKeyDown(Gamemanager.KeySet.Wp1))
                {
                    Gamemanager.playerScript.UwN = 1;
                }
                else if (Input.GetKeyDown(Gamemanager.KeySet.Wp2))
                {
                    Gamemanager.playerScript.UwN = 2;
                }
            }
            else
            {
                Debug.Log("스킬이 쿨타임일 때 무기를 변경할 수 없습니다.");
            }
        }
    }
    public void WeaponSwapUpdate() {
        if (Gamemanager.playerScript.UwN == 1)
        {
            Gamemanager.playerScript.weapon = Gamemanager.playerScript.weapon1;
            Gamemanager.playerScript.WeaponUse.w1.SetActive(true);
            Gamemanager.playerScript.WeaponUse.w2.SetActive(false);
            
        }
        else if (Gamemanager.playerScript.UwN == 2) {
            Gamemanager.playerScript.weapon = Gamemanager.playerScript.weapon2;
            Gamemanager.playerScript.WeaponUse.w1.SetActive(false);
            Gamemanager.playerScript.WeaponUse.w2.SetActive(true);
            
        }
    }
}
