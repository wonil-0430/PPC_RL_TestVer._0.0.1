using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : Util
{
    public RP roomposition;
    public Sprite DBD;//���� �ٴ��̹���
    public GameObject door_pre;//�� ������
    public GameObject[] doorlist = new GameObject[4];
    private bool clear = false; //���� Ŭ���� �Ǿ��°�?
    //���� Ŭ���� ���η� ������ false�� �����ǰ�
    //���� Ŭ���� ������ ���� ��� true�� ����
    //���� Ŭ���� �������ִ°��� Ȯ���ϱ� ���ؼ��̴�.
    
    public abstract void startroombody();//���� ���۵� �� ������ �ൿ ex) ���� ����, ����� ���� ���

    public void startroom() {
        if (!clear) {
            startroombody();
        }
    }

    public abstract bool ClearCondi();//���� Ŭ������ ���� ex) ���� 0�����̴�, ����� �ذ�Ǿ��� ���
    //Ŭ���� ������ �������� ������ false�� �����ҽ� true�� return
    protected virtual void clearroom() {//���� Ŭ���� �Ǿ��� �� ����
        //�������ɼ� ����
        createdoor();
    }

    protected void createdoor() {
        bool[] doorboollist = new bool[4];
        for (int i = 0; i < 4; i++) {
            doorboollist[i] = true;
        }
        int x = roomposition.x;
        int y = roomposition.y;
        //��Ż�� �����ؾ��� ������ ã�� if��
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
        //if������ ���� ������ doorlist�� �̿��Ͽ� true�� �������� ���� ����
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
