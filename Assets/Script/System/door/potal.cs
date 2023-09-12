using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potal : Util
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "player" && Input.GetKey(KeyCode.F))
        {
            gamemanager.GetComponent<Gamemanager>().floorCount += 1;
            gamemanager.GetComponent<Gamemanager>().FloorUpdate();
            Gamemanager.playerScript.PlayerMove.GetComponent<PlayerMovementChess>().playerCp = new Cp(4, 4);
        }
    }
}
