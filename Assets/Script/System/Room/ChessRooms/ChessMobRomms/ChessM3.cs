using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessM3 : mobChessRoom
{
    protected override void Awake()
    {
        base.Awake();
        mobcount = 1;//필드의 몹의 갯수가 들어간다.
    }

    public override void startroombody()
    {
        Instantiate(mob1, transform).GetComponent<night>().MobSet(500, 100, new Cp(0, 4));//몹의 소환 부분이 들어간다.
    }
}
