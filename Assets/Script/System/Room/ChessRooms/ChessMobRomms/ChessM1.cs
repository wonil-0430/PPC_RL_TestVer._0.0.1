using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessM1 : mobChessRoom
{
    protected override void Awake()
    {
        base.Awake();
        mobcount = 1;//�ʵ��� ���� ������ ����.
    }
    public override void startroombody()
    {
        Instantiate(mob1, transform).GetComponent<pawn>().MobSet(500, 100, new Cp(0, 4), 1);//���� ��ȯ �κ��� ����.
    }
}

