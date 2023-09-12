using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : Util
{
    public RP roomposition;
    public Sprite DBD;//방의 바닥이미지
    public GameObject door_pre;//문 프리팹
    public GameObject[] doorlist = new GameObject[4];
    private bool clear = false; //방이 클리어 되었는가?
    //방의 클리어 여부로 생성시 false로 생성되고
    //방이 클리어 된적이 있을 경우 true로 지정
    //방이 클리어 된적이있는가를 확인하기 위해서이다.
    
    public abstract void startroombody();//룸이 시작될 때 실행할 행동 ex) 몹의 생성, 기믹의 시작 등등

    public void startroom() {
        if (!clear) {
            startroombody();
        }
    }

    public abstract bool ClearCondi();//방을 클리어할 조건 ex) 몹이 0마리이다, 기믹이 해결되었다 등등
    //클리어 조건을 만족하지 않을시 false를 만족할시 true를 return
    protected virtual void clearroom() {//룸이 클리어 되었을 때 실행
        //오류가능성 있음
        createdoor();
    }

    protected void createdoor() {
        bool[] doorboollist = new bool[4];
        for (int i = 0; i < 4; i++) {
            doorboollist[i] = true;
        }
        int x = roomposition.x;
        int y = roomposition.y;
        //포탈을 생성해야할 방향을 찾는 if문
        if (x == 8)
        {
            doorboollist[1] = false;
            if (transform.GetComponentInParent<Floor>().RoomList[x - 1, y] == null)
            {
                doorboollist[3] = false;
            }
        }
        else if (x == 0)
        {
            doorboollist[3] = false;
            if (transform.GetComponentInParent<Floor>().RoomList[x + 1, y] == null)
            {
                doorboollist[1] = false;
            }
        }
        else {
            if (transform.GetComponentInParent<Floor>().RoomList[x + 1, y] == null)
            {
                doorboollist[1] = false;
            }
            if (transform.GetComponentInParent<Floor>().RoomList[x - 1, y] == null)
            {
                doorboollist[3] = false;
            }
        }
        if (y == 8)
        {
            doorboollist[0] = false;
            if (transform.GetComponentInParent<Floor>().RoomList[x, y - 1] == null)
            {
                doorboollist[2] = false;
            }
        }
        else if (y == 0)
        {
            doorboollist[2] = false;
            if (transform.GetComponentInParent<Floor>().RoomList[x, y + 1] == null)
            {
                doorboollist[0] = false;
            }
        }
        else {
            if (transform.GetComponentInParent<Floor>().RoomList[x, y - 1] == null)
            {
                doorboollist[2] = false;
            }
            if (transform.GetComponentInParent<Floor>().RoomList[x, y + 1] == null)
            {
                doorboollist[0] = false;
            }
        }
        //if문으로 부터 수정된 doorlist를 이용하여 true인 방향으로 문을 생성
        for (int i = 0; i < 4; i++) {
            if (doorboollist[i] == true) { 
                doorlist[i] = Instantiate(door_pre, transform);
                doorlist[i].name = i.ToString();
                doorlist[i].GetComponent<door>().direction = i;
                doorlist[i].GetComponent<door>().rp = roomposition;
                doorlist[i].GetComponent<door>().StartDoor();

            }
        }

    }

    protected virtual void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = DBD;
    }

    protected virtual void Update()
    {
        if (!clear && ClearCondi()) {
            clear = true;
            clearroom();
        }
    }
}
