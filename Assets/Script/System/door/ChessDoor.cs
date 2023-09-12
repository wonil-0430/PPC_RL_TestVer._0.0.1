using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessDoor : door
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.transform.position = rp.getPosition() + xy + new Vector3(1.25f,1.25f,0);
            transform.parent.parent.GetComponent<Floor>().roompointer.x += (int)roommove.x;
            transform.parent.parent.GetComponent<Floor>().roompointer.y += (int)roommove.y;
            Gamemanager.playerScript.playerRP.x += (int)roommove.x;
            Gamemanager.playerScript.playerRP.y += (int)roommove.y;
            gamemanager.now_floor.GetComponent<Floor>().RoomList[Gamemanager.playerScript.playerRP.x, Gamemanager.playerScript.playerRP.y].GetComponent<Room>().startroom();
            Gamemanager.playerScript.transform.parent = gamemanager.now_floor.GetComponent<Floor>().RoomList[Gamemanager.playerScript.playerRP.x, Gamemanager.playerScript.playerRP.y].transform;
            Gamemanager.playerScript.PlayerMove.GetComponent<PlayerMovementChess>().playerCp = new Cp(4, 4);

            collision.transform.localPosition = new Vector3(12.5f, 12.5f, 0);

        }
    }
}
