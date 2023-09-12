using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : Util
{
    [SerializeField] Transform player;
    [SerializeField] float smoothing = 0.2f;
    [SerializeField] Vector2 minCameraBoundary;
    [SerializeField] Vector2 maxCameraBoundary;
    private GameObject floor;
    private void FixedUpdate()
    {
        floor = gamemanager.now_floor;

        minCameraBoundary.x = floor.transform.position.x + Gamemanager.playerScript.playerRP.getPosition().x -18;
        maxCameraBoundary.x = floor.transform.position.x + Gamemanager.playerScript.playerRP.getPosition().x + 18;
        minCameraBoundary.y = floor.transform.position.y + Gamemanager.playerScript.playerRP.getPosition().y - 58;
        maxCameraBoundary.y = floor.transform.position.y + Gamemanager.playerScript.playerRP.getPosition().y + 58;
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);

        targetPos.x = Mathf.Clamp(targetPos.x, minCameraBoundary.x, maxCameraBoundary.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minCameraBoundary.y, maxCameraBoundary.y);

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
    }
}
