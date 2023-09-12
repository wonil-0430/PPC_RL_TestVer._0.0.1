using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementChess : PlayerMove
{
    public Cp playerCp = new Cp(4,4);

    protected override void Dash()
    {
        Gamemanager.playerScript.playerstat.DashCool = 0;//���������� �뽬�� �ð��� 0���� ������Ʈ
        Gamemanager.playerScript.canhit = false;//�ǰݹ���
        Gamemanager.player.layer = 8;
        StartCoroutine(DashWait(0.3f));//Coroutine DashWait�� 0.1�� �μ��� �ΰ� ȣ��
                                       //�� �뽬�� ����Ǹ� �̵��ӵ��� 5�谡 ���� 0.1���� �ٽ� ���󺹱��Ѵ�.
    }

    private IEnumerator DashWait(float time)
    { //�ڷ�ƾ �Լ�
        yield return new WaitForSeconds(time);//time�� �ð���ŭ ��ٸ����� ������ �ڵ带 ����
        Gamemanager.playerScript.canhit = true;
        Gamemanager.player.layer = 6;
    }

    protected override bool GetKeyType(KeyCode code)
    {
        if (Input.GetKeyDown(code))
        {
            return true;
        }
        else {
            return false;
        }
    }

    protected override void Up()
    {
        Cpmove(playerCp + new Cp(0, 1));
    }
    protected override void Down()
    {
        Cpmove(playerCp + new Cp(0, -1));
    }
    protected override void Right()
    {
        Cpmove(playerCp + new Cp(1, 0));
        Gamemanager.player.GetComponent<SpriteRenderer>().flipX = false;
    }
    protected override void Left()
    {
        Cpmove(playerCp + new Cp(-1, 0));
        Gamemanager.player.GetComponent<SpriteRenderer>().flipX = true;
    }
    protected override void RightDown()
    {
        
    }
    protected override void RightUp()
    {
        
    }
    protected override void LeftDown()
    {
        
    }

    protected override void LeftUp()
    {
        
    }

    protected override void Stop()
    {
        
    }


    public void Cpmove(Cp cp) {
        if ((0 <= cp.x && cp.x <= 7) && (0 <= cp.y && cp.y <= 7))
        {
            if (!transform.parent.GetComponent<ChessRoom>().chesspan[cp.x, cp.y])
            {
                transform.localPosition = cp.getpositon();
                playerCp = cp;
            }
        }
    }
}
