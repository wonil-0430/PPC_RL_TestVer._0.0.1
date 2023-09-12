using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMomentNormal : PlayerMove
{

    //�Ϲ��̵��� 8�����̹Ƿ� �̵����� 0, 45, 90, 135, 180, 225, 270, 315�̴�.
    //�̵��ӵ��� �׻� �����ϰ� �ϱ����ؼ� velocity x, y�� ������ ���� speed�� �����̿����Ѵ�.
    //�뽬�� ����
    //�뽬�� ������ �̵�������Ʈ�� k��� ���� ����� ���̰� �̸� ���������� ���̰� Ư���ð��� �ٽ� �̸� ���󺹱��ϴ� �����̴�.
    //�� speed�� k�� �������ִ�.
    //flip
    //�÷��̾��� �����̴� ������ x�� �������� +. -�̳Ŀ� ���� player�� flipx�� �����Ѵ�.
    //�÷��̾� �̹����� �⺻���� ������ ���������Ƿ� velocity�� ����̸� flip�� false, �����̸� true�̴�.
    


    //DashCool�� ���������� �뽬�� ���������κ��� ������ �ð��� ���������� ����Ѵ�.
    //DashCoolDown�� �뽬�� �ϰ��� ���ʰ��� ���� �����Ұ������� �����Ѵ�.
    protected override void Dash()
    {
        Gamemanager.playerScript.playerstat.DashCool = 0;//���������� �뽬�� �ð��� 0���� ������Ʈ
        k *= 5f;//�ӵ� ����� 5���
        Gamemanager.playerScript.canhit = false;//�ǰݹ���
        Gamemanager.player.layer = 8;
        StartCoroutine(DashWait(0.1f));//Coroutine DashWait�� 0.1�� �μ��� �ΰ� ȣ��
                                       //�� �뽬�� ����Ǹ� �̵��ӵ��� 5�谡 ���� 0.1���� �ٽ� ���󺹱��Ѵ�.
    }

    private IEnumerator DashWait(float time) { //�ڷ�ƾ �Լ�
        yield return new WaitForSeconds(time);//time�� �ð���ŭ ��ٸ����� ������ �ڵ带 ����
        Gamemanager.playerScript.canhit = true;
        Gamemanager.player.layer = 6;
        k /= 5f;//�̵� �ӵ������ ���󺹱�
    }

    protected override void RightUp()
    {
        rigidy.velocity = new Vector3(Mathf.Sqrt(Mathf.Pow((Gamemanager.playerScript.playerstat.speed * k), 2) / 2), Mathf.Sqrt(Mathf.Pow((Gamemanager.playerScript.playerstat.speed * k), 2) / 2), 0);
        Gamemanager.player.GetComponent<SpriteRenderer>().flipX = false;
    }
    protected override void LeftUp()
    {
        rigidy.velocity = new Vector3(-Mathf.Sqrt(Mathf.Pow((Gamemanager.playerScript.playerstat.speed * k), 2) / 2), Mathf.Sqrt(Mathf.Pow((Gamemanager.playerScript.playerstat.speed * k), 2) / 2), 0);
        Gamemanager.player.GetComponent<SpriteRenderer>().flipX = true;
    }
    protected override void RightDown()
    {
        rigidy.velocity = new Vector3(Mathf.Sqrt(Mathf.Pow((Gamemanager.playerScript.playerstat.speed * k), 2) / 2), -Mathf.Sqrt(Mathf.Pow((Gamemanager.playerScript.playerstat.speed * k), 2) / 2), 0);
        Gamemanager.player.GetComponent<SpriteRenderer>().flipX = false;
    }
    protected override void LeftDown()
    {
        rigidy.velocity = new Vector3(-Mathf.Sqrt(Mathf.Pow((Gamemanager.playerScript.playerstat.speed * k), 2) / 2), -Mathf.Sqrt(Mathf.Pow((Gamemanager.playerScript.playerstat.speed * k), 2) / 2), 0);
        Gamemanager.player.GetComponent<SpriteRenderer>().flipX = true;
    }
    protected override void Up()
    {
        rigidy.velocity = new Vector3(0, Gamemanager.playerScript.playerstat.speed * k, 0);
    }
    protected override void Down()
    {
        rigidy.velocity = new Vector3(0, -Gamemanager.playerScript.playerstat.speed * k, 0);
    }
    protected override void Right()
    {
        rigidy.velocity = new Vector3(Gamemanager.playerScript.playerstat.speed * k, 0, 0);
        Gamemanager.player.GetComponent<SpriteRenderer>().flipX = false;
    }
    protected override void Left()
    {
        rigidy.velocity = new Vector3(-Gamemanager.playerScript.playerstat.speed * k, 0, 0);
        Gamemanager.player.GetComponent<SpriteRenderer>().flipX = true;
    }
    protected override void Stop() {
        rigidy.velocity = new Vector3(0, 0, 0);
    }
}
