using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobRoom : Room
{
    public int mobcount;//�ش� �濡 �ִ� ������ŭ ����

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
}
