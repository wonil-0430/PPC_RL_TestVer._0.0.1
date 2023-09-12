using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : Util
{
    public RP rp;
    public int direction;
    protected Vector3 xy;
    protected Vector2 roommove = new Vector2(0, 0);
    public float jump;


    // Start is called before the first frame update
    public void StartDoor()
    {   
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90 * direction));
        if (direction == 0)
        {
            xy = new Vector3(0,jump,0);
            roommove.y = 1;
            transform.position = transform.parent.position + new Vector3(0, 90, 0);
        }
        else if (direction == 1) {
            xy = new Vector3(jump, 0, 0);
            roommove.x = 1;
            transform.position = transform.parent.position + new Vector3(90, 0, 0);
        }
        else if (direction == 2)
        {
            xy = new Vector3(0,-jump,0);
            roommove.y = -1;
            transform.position = transform.parent.position + new Vector3(0, -90, 0);
        }
        else if (direction == 3)
        {
            xy = new Vector3(-jump, 0, 0);
            roommove.x = -1;
            transform.position = transform.parent.position + new Vector3(-90, 0, 0);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //collision.transform.position = rp.getPosition() + xy;
            transform.parent.parent.GetComponent<Floor>().roompointer.x += (int)roommove.x;
            transform.parent.parent.GetComponent<Floor>().roompointer.y += (int)roommove.y;
            Gamemanager.playerScript.playerRP.x += (int)roommove.x;
            Gamemanager.playerScript.playerRP.y += (int)roommove.y;
            this.transform.parent.transform.parent.GetComponent<Floor>().RoomList[Gamemanager.playerScript.playerRP.x, Gamemanager.playerScript.playerRP.y].GetComponent<Room>().startroom();
            Gamemanager.playerScript.transform.parent = this.transform.parent.transform.parent.GetComponent<Floor>().RoomList[Gamemanager.playerScript.playerRP.x, Gamemanager.playerScript.playerRP.y].transform;
            collision.transform.localPosition = new Vector3(0, 0, 0);

        }
    }
}