using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class CheesMob : Mob
{
    public Cp MobPosition;
    public GameObject atkFloor;

    protected override void Awake()
    {
        base.Awake();
        transform.localPosition = MobPosition.getpositon();
    }

    public void MobSet(float hp, float str, Cp positon) {
        base.MobSet(hp, str);
        this.MobPosition = positon;
    }

    protected override void die()
    {
        base.die();
    }

    protected void Moveatk(Cp atkPosition) {
        GameObject nowobj = Instantiate(atkFloor, transform);
        nowobj.transform.position = transform.parent.position + atkPosition.getpositon();
        StartCoroutine(MatkAf(nowobj, atkPosition, 0.5f));
    }

    protected void Moveatk(Cp atkPosition, float wait)
    {
        GameObject nowobj = Instantiate(atkFloor, transform);
        nowobj.transform.position = transform.parent.position + atkPosition.getpositon();
        StartCoroutine(MatkAf(nowobj, atkPosition, wait));
    }

    protected virtual void atk(Cp atkPosition)
    {
        GameObject nowobj = Instantiate(atkFloor, transform);
        nowobj.transform.position = transform.parent.position + atkPosition.getpositon();
        StartCoroutine(atkAf(nowobj, atkPosition, 0.5f));
    }
    protected void atk(Cp atkPosition, float wait)
    {
        GameObject nowobj = Instantiate(atkFloor, transform);
        nowobj.transform.position = transform.parent.position + atkPosition.getpositon();
        StartCoroutine(atkAf(nowobj, atkPosition, wait));
    }

    protected virtual IEnumerator MatkAf(GameObject obj, Cp atkPosition, float wait)
    { //재장전 코루틴 코드
        yield return new WaitForSeconds(wait);//time의 시간이후 아래의 코드를 실행
        Destroy(obj);
        MobPosition = atkPosition;
        transform.localPosition = MobPosition.getpositon();
        if (MobPosition == Gamemanager.playerScript.PlayerMove.GetComponent<PlayerMovementChess>().playerCp) {
            Gamemanager.playerScript.getdamage(Str);
        }
    }

    protected IEnumerator atkAf(GameObject obj, Cp atkPosition, float wait)
    { //재장전 코루틴 코드
        yield return new WaitForSeconds(wait);//time의 시간이후 아래의 코드를 실행
        Destroy(obj);
        if (MobPosition == Gamemanager.playerScript.PlayerMove.GetComponent<PlayerMovementChess>().playerCp)
        {
            Gamemanager.playerScript.getdamage(Str);
        }
    }
}
