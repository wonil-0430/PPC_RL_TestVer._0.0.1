using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobChessRoom : ChessRoom
    //몹 형 체스룸의 기본형
{
    public GameObject mob1;
    public int mobcount;

    public override bool ClearCondi()//클리어조건 중괄호안에 특정조건을 만족할 때 TRUE를 반환, 아닐 때는 FALSE를 반환하도록 하시면 됩니다.
    {
        if (mobcount == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        //mob count set
    }

    public override void startroombody()
    {
        //mob summon
    }

    protected override void clearroom()
    {
        base.clearroom();
    }
}
