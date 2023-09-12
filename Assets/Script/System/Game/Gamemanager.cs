using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : Util
{
    //game에서의 player와 player의 스크립트
    public static GameObject player;
    public static Player playerScript;
    

    //MoveSetting 구조체
    public static KeySetting KeySet;
    public static WeaponList WList;
    public static  GameObject[] WeaponT = new GameObject[2];

    //roomposition
    public GameObject now_floor;
    public GameObject[] floor_feb = new GameObject[10];
    public GameObject[] boss_floor_feb = new GameObject[10];
    public GameObject[,] floor_list = new GameObject[10,11];
    public Transform game;
    public int floorCount;
    
    //UI
    public static bool isPause = false;
    public GameObject MenuSet;
    public GameObject SettingMenu;

    private void Awake()
    {
        
        game = GameObject.Find("Game").transform;

        player = GameObject.FindWithTag("player");
        playerScript = player.GetComponent<Player>();
        KeySet = new KeySetting(true);
        WList = new WeaponList(true);
        WeaponT[0] = GameObject.Find("Weapon1");
        WeaponT[1] = GameObject.Find("Weapon2");

        //게임 속에 존재하는 무기들의 프리팹들
        WList.M1 = Resources.Load("Prefab/Weapon/Gun/Gun/M1") as GameObject;
        WList.Pistol = Resources.Load("Prefab/Weapon/Gun/Gun/Pistol") as GameObject;
        
        //weapon
        player.GetComponent<WeaponUse>().w1 = Instantiate(WList.M1, WeaponT[0].GetComponent<Transform>());
        player.GetComponent<WeaponUse>().w2 = Instantiate(WList.Pistol, WeaponT[1].GetComponent<Transform>());

        playerScript.weapon1 = player.GetComponent<WeaponUse>().w1.GetComponent<M1>();
        playerScript.weapon = playerScript.weapon1;
        playerScript.weapon2 = player.GetComponent<WeaponUse>().w2.GetComponent<Pistol>();

        //플레이어 최초 실행시 플레이어를 1층 4,4로비에 배치하는 코드
        for (int i = 1; i <= 100; i++)
        {
            if (i % 10 != 0)
            {
                CreateFloor(i);
            }
            else {
                CreateBossFloor(i);
            }
        }
        floorCount = 1;
        now_floor = floor_list[1, 0];
        FloorUpdate();

    }

    private void CreateFloor(int floornumber) {
        int i = (floornumber % 10);
        int t = 0;
        t = (floornumber - i) / 10;

            floor_list[i, t] = Instantiate(floor_feb[t], game);
            floor_list[i, t].name = (floornumber).ToString();
            floor_list[i, t].transform.position += new Vector3(i * 2000, t * 2000, 0);
            floor_list[i, t].GetComponent<Floor>().setPol(i);
    }
    private void CreateBossFloor(int floornumber) {
        int i = (floornumber % 10);
        int t = 0;
        t = (floornumber - i) / 10;
        floor_list[i,t] = Instantiate(boss_floor_feb[0], game);
        floor_list[i,t].name = (floornumber).ToString();
        floor_list[i,t].transform.position += new Vector3(i * 2000, t * 2000, 0);
    }

    public void FloorUpdate() {
        int i = (floorCount % 10);
        int t = 0;
        if (floorCount >= 10)
        {
            t = (floorCount - i) / 10;
        }
        now_floor = floor_list[i, t];
        player.transform.SetParent(now_floor.GetComponent<Floor>().RoomList[4, 4].transform);

        now_floor.GetComponent<Floor>().RoomList[4, 4].GetComponent<Room>().startroom();
        player.transform.localPosition = new Vector3(12.5f, 12.5f, 0);
    }


    public float GetDamage(bool ciri) {
        if (ciri)
        {
            return (playerScript.weapon.wo.atk * (2 + playerScript.weapon.wo.critical_damage));
        }
        else {
            return playerScript.weapon.wo.atk;
        }

    }

    public bool GetCritical() {//1~1000 /10 1~100
        if (((float)Random.Range(1, 1001) / 10) <= Mathf.Round(playerScript.playerstat.critical + playerScript.weapon.wo.critical))
            //0~100사이의 랜덤값이 총합 크리티컬 확률 이하면 치명타
        {
            return true;
        }
        else {
            return false;
        }
    }

    public void Cheek() {
        Debug.Log("Gamemanager is Online");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("작동함");

            if(!Gamemanager.isPause)
                CallMenu();
            else
                CloseMenu();
        }

    }

    private void CallMenu()
    {
        Gamemanager.isPause = true;
        gamemanager.MenuSet.SetActive(true);
        Time.timeScale = 0f;
        PlayerMove.canmove = false;
    }
    
    private void CloseMenu()
    {
        Gamemanager.isPause = false;
        gamemanager.MenuSet.SetActive(false);
         gamemanager.SettingMenu.SetActive(false);
        Time.timeScale = 1f;
        PlayerMove.canmove = true;
    }


    public void ClickContinue()
    {
        CloseMenu();
        Debug.Log("계속하기");
    }

    public void ClickSetting()
    {
        gamemanager.SettingMenu.SetActive(true);
        Debug.Log("설정");
    }

    public void ClickExit()
    {
        Debug.Log("나가기");
    }
}