using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobRoom : Room
{
    public int mobcount;//해당 방에 있는 몹수만큼 선언

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
}
