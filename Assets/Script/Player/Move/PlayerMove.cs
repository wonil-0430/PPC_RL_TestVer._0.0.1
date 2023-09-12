using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMove : Util
{
    public Rigidbody2D rigidy;// ÷  ̾    rigidbody
                              //rigidbody   velocity              Player   velocity        ϱ     Ͽ  rigidbody               ʿ   

    protected float k = 1;// ̵         

    // ش         gamemanager
    //public Gamemanager gamemanager;
    //public GameObject player;     rigidy        ϱ    Ͽ             Ʈ      ÷  ̾ ã    ʿ䰡    
    //       Gamemanager   player           ʾ    Ƿ  player                ʿ        Gamemanager   player        Ƿ   ش                     
    public static bool canmove = true;


    private void Awake()
    {
        rigidy = GetComponent<Rigidbody2D>();// ÷  ̾    rigidbody          ȣ  
    }

    private void FixedUpdate()
    {
        Gamemanager.playerScript.playerstat.DashCool += Time.deltaTime;// ÷  ̾     뽬   Ÿ      ð     帧            
    }
    public void moveUpdate()
    {
        if(canmove){
            if (GetKeyType(Gamemanager.KeySet.UpKey) && !GetKeyType(Gamemanager.KeySet.DownKey))
            {
                if (GetKeyType(Gamemanager.KeySet.Rightkey) && !GetKeyType(Gamemanager.KeySet.LeftKey))//    
                {
                    RightUp();
                }
                else if (!GetKeyType(Gamemanager.KeySet.Rightkey) && GetKeyType(Gamemanager.KeySet.LeftKey))//    
                {
                    LeftUp();
                }
                else
                {
                    Up();
                }

            }//          
            else if (!GetKeyType(Gamemanager.KeySet.UpKey) && GetKeyType(Gamemanager.KeySet.DownKey))
            {
                if (GetKeyType(Gamemanager.KeySet.Rightkey) && !GetKeyType(Gamemanager.KeySet.LeftKey))//    
                {
                    RightDown();
                }
                else if (!GetKeyType(Gamemanager.KeySet.Rightkey) && GetKeyType(Gamemanager.KeySet.LeftKey))//    
                {
                    LeftDown();
                }
                else
                {
                    Down();
                }
            } // Ʒ         
            else
            {
                if (GetKeyType(Gamemanager.KeySet.Rightkey) && !GetKeyType(Gamemanager.KeySet.LeftKey))//    
                {
                    Right();
                }
                else if (!GetKeyType(Gamemanager.KeySet.Rightkey) && GetKeyType(Gamemanager.KeySet.LeftKey))//    
                {
                    Left();
                }
                else
                {
                    Stop();
                    rigidy.velocity = new Vector3(0, 0, 0);
                }

            }
            //y    ̵           
        }
        else
        {
            Stop();
            rigidy.velocity = new Vector3(0, 0, 0);
        }// ÷  ̾                 Լ 
    }
    public void dashUpdate() {
        if (GetKeyType(Gamemanager.KeySet.Dash))
        {// 뽬Ű            
            if (canmove)
            {
                if (Gamemanager.playerScript.playerstat.DashCool >= Gamemanager.playerScript.playerstat.DashCoolDown)
                {// 뽬                  
                    Dash();
                }
            }
        }
    }// ÷  ̾     뽬       Լ 
    protected virtual bool GetKeyType(KeyCode code) {
        if (Input.GetKey(code))
        {
            return true;
        }
        else {
            return false;
        }
    }
    protected abstract void RightUp();
    protected abstract void RightDown();
    protected abstract void LeftUp();
    protected abstract void LeftDown();
    protected abstract void Up();
    protected abstract void Down();
    protected abstract void Right();
    protected abstract void Left();
    protected abstract void Stop();
    protected abstract void Dash();
}
