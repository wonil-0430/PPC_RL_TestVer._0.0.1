using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawn : CheesMob
{
    public int direction;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        transform.localPosition = MobPosition.getpositon();
        InvokeRepeating("atk1", 2f, 2f);
    }

    public void MobSet(float hp, float str, Cp positon, int direction)
    {
        base.MobSet(hp, str, positon);
        this.direction = direction;
    }

    private void explosion() {
        for (int i = 0; i < MobPosition.x; i++) {
            atk(new Cp(i, MobPosition.y), 0.2f);
        }
        for (int i = MobPosition.x + 1; i < 8; i++)
        {
            atk(new Cp(i, MobPosition.y), 0.2f);
        }
        for (int i = 0; i < MobPosition.y; i++)
        {
            atk(new Cp(MobPosition.x, i), 0.2f);
        }
        for (int i = MobPosition.y + 1; i < 8; i++)
        {
            atk(new Cp(MobPosition.x, i), 0.2f);
        }
        for (int i = 1; MobPosition.x + i < 8 && MobPosition.y + i < 8; i++) {
            atk(MobPosition + new Cp(i,i), 0.2f);
        }
        for (int i = 1; MobPosition.x - i >= 0 && MobPosition.y + i < 8; i++)
        {
            atk(MobPosition + new Cp(-i, i), 0.2f);
        }
        for (int i = 1; MobPosition.x + i < 8 && MobPosition.y - i >= 0; i++)
        {
            atk(MobPosition + new Cp(i, -i), 0.2f);
        }
        for (int i = 1; MobPosition.x - i >= 0 && MobPosition.y - i >= 0; i++)
        {
            atk(MobPosition + new Cp(-i, -i), 0.2f);
        }
        StartCoroutine(delaydie(0.2f));
    }

    protected override IEnumerator MatkAf(GameObject obj, Cp atkPosition, float wait)
    { //재장전 코루틴 코드
        yield return new WaitForSeconds(wait);//time의 시간이후 아래의 코드를 실행
        Destroy(obj);
        MobPosition = atkPosition;
        transform.localPosition = MobPosition.getpositon();
        if (MobPosition == Gamemanager.playerScript.PlayerMove.GetComponent<PlayerMovementChess>().playerCp)
        {
            Gamemanager.playerScript.getdamage(Str);
        }
        if (MobPosition * Cp.unitCp(direction).abs() == new Cp(Cp.unitCp(direction) * new Vector2(3.5f, 3.5f) + new Vector2(3.5f, 3.5f))* Cp.unitCp(direction).abs()) {
            explosion();
        }
    }

    protected IEnumerator delaydie(float wait)
    { 
        yield return new WaitForSeconds(wait);//time의 시간이후 아래의 코드를 실행
        die();
    }

    private void atk1()
    {
        if (MobPosition + Cp.unitCp(direction) + Cp.unitCp(direction + 1) == Gamemanager.playerScript.PlayerMove.GetComponent<PlayerMovementChess>().playerCp)
        {
            Moveatk(MobPosition + Cp.unitCp(direction) + Cp.unitCp(direction + 1));
        }
        else if (MobPosition + Cp.unitCp(direction) + Cp.unitCp(direction + 3) == Gamemanager.playerScript.PlayerMove.GetComponent<PlayerMovementChess>().playerCp)
        {
            Moveatk(MobPosition + Cp.unitCp(direction) + Cp.unitCp(direction + 3));
        }
        else
        {
            Moveatk(MobPosition + Cp.unitCp(direction));
        }
    }
}