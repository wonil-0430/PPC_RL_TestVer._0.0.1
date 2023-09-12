using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMomentNormal : PlayerMove
{

    //일반이동은 8방향이므로 이동각은 0, 45, 90, 135, 180, 225, 270, 315이다.
    //이동속도를 항상 일정하게 하기위해서 velocity x, y의 제곱의 합이 speed의 제곱이여야한다.
    //대쉬의 원리
    //대쉬의 원리는 이동업데이트에 k라는 최종 계수를 붙이고 이를 순간적으로 높이고 특정시간후 다시 이를 원상복구하는 원리이다.
    //즉 speed에 k가 곱해져있다.
    //flip
    //플레이어의 움직이는 방향이 x축 기준으로 +. -이냐에 따라서 player의 flipx를 설정한다.
    //플레이어 이미지는 기본으로 우측을 보고있으므로 velocity가 양수이면 flip은 false, 음수이면 true이다.
    


    //DashCool은 마지막으로 대쉬를 한지점으로부터 몇초의 시간이 지났는지를 기록한다.
    //DashCoolDown은 대쉬를 하고나서 몇초간의 쿨을 지정할건인지를 지정한다.
    protected override void Dash()
    {
        Gamemanager.playerScript.playerstat.DashCool = 0;//마지막으로 대쉬한 시간을 0으로 업데이트
        k *= 5f;//속도 계수를 5배로
        Gamemanager.playerScript.canhit = false;//피격무시
        Gamemanager.player.layer = 8;
        StartCoroutine(DashWait(0.1f));//Coroutine DashWait을 0.1을 인수로 두고 호출
                                       //즉 대쉬가 실행되면 이동속도가 5배가 된후 0.1초후 다시 원상복구한다.
    }

    private IEnumerator DashWait(float time) { //코루틴 함수
        yield return new WaitForSeconds(time);//time의 시간만큼 기다린이후 다음의 코드를 실행
        Gamemanager.playerScript.canhit = true;
        Gamemanager.player.layer = 6;
        k /= 5f;//이동 속도계수를 원상복구
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
