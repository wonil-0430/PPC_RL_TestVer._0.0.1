using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobChessRoom : ChessRoom
    //�� �� ü������ �⺻��
{
    public GameObject mob1;
    public int mobcount;

    public override bool ClearCondi()//Ŭ�������� �߰�ȣ�ȿ� Ư�������� ������ �� TRUE�� ��ȯ, �ƴ� ���� FALSE�� ��ȯ�ϵ��� �Ͻø� �˴ϴ�.
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
