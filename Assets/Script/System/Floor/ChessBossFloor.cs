using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBossFloor : Floor
{
    public GameObject BossRoom;
    protected override void Awake()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                RoomList[i, j] = null;
            }
        }
        RoomList[4, 4] = Instantiate(lobby, transform);
        RoomList[4, 5] = Instantiate(BossRoom, transform);
    }
}
