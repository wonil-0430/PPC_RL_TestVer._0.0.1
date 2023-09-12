using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Util
{
    public GameObject[,] RoomList = new GameObject[9, 9];
    public GameObject[] roompre = new GameObject[2];
    public GameObject lobby;
    public RP roompointer;

    protected virtual void Awake()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                RoomList[i, j] = null;
            }
        }
        room_layout();
    }

    public void room_layout()
    {
        roompointer = new RP(4, 4);
        CreateRoom(roompointer, lobby);
    }
    public GameObject getRandRoom()
    {
        //return roompre[Random.Range(0, 4)];
        return roompre[3];
    }

    //방생성 함수화
    public void CreateRoom(RP rp)
    {
        RoomList[rp.x, rp.y] = Instantiate(getRandRoom(), this.transform);
        RoomList[rp.x, rp.y].transform.position += rp.getPosition();
        RoomList[rp.x, rp.y].GetComponent<Room>().roomposition = rp;
        RoomList[rp.x, rp.y].name = rp.x.ToString() + ", " + rp.y.ToString();
    }
    public void CreateRoom(RP rp, GameObject pre)
    {
        RoomList[rp.x, rp.y] = Instantiate(pre, this.transform);
        RoomList[rp.x, rp.y].transform.position += rp.getPosition();
        RoomList[rp.x, rp.y].GetComponent<Room>().roomposition = rp;
        RoomList[rp.x, rp.y].name = rp.x.ToString() + ", " + rp.y.ToString();
    }

    protected RP Rand4(RP rp)
    {
        List<RP> roomlist = new List<RP>();
        List<RP> removelist = new List<RP>();
        roomlist.Clear();
        removelist.Clear();
        for (int i = 0; i < 4; i++) {
            roomlist.Add(rp + RP.unitRP(i));
        }
        for (int i = 0; i < 4; i++)
        {
            if (!roomlist[i].RangCheek())
            {
                removelist.Add(roomlist[i]);
            }
            else if (null != RoomList[roomlist[i].x, roomlist[i].y]) {
                removelist.Add(roomlist[i]);
            }
        }
        for (int i = 0; i < removelist.Count; i++) {
            roomlist.Remove(removelist[i]);
            
        }
        return roomlist[Random.Range(0, roomlist.Count)];
    }

    public void setPol(int r)
    {
        for (int i = 0; i < r; i++)
        {
            roompointer = Rand4(roompointer);
            CreateRoom(roompointer);
        }
    }
}
