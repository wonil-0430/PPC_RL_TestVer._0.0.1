using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessM2 : mobChessRoom
{
    protected override void Awake()
    {
        base.Awake();
        mobcount = 3;//필드의 몹의 갯수가 들어간다.
    }

    public override void startroombody()
    {
        Instantiate(mob1, transform).GetComponent<pawn>().MobSet(500, 100, new Cp(0, 4), 1);//몹의 소환 부분이 들어간다.
        Instantiate(mob1, transform).GetComponent<pawn>().MobSet(500, 100, new Cp(5, 0), 4);
        Instantiate(mob1, transform).GetComponent<pawn>().MobSet(500, 100, new Cp(4, 7), 2);
    }
}
