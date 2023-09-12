using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButton(0))
        {

            SceneManager.LoadScene("Ingame");

        }
    }
}
