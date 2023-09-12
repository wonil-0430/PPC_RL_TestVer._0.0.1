using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bishop : CheesMob
{
    void Start()
    {
        transform.localPosition = MobPosition.getpositon();
        InvokeRepeating("Move", 2f, 3f);
        //2.5s
        InvokeRepeating("atk1", 3f, 3f);
        //3.5s√÷√ 
        //2.5s
    }

    private void Move()
    {
        List<Cp> movelist = new List<Cp>();
        movelist.Clear();
        for (int i = 1; MobPosition.x + i < 8 && MobPosition.y + i < 8; i++)
        {
            movelist.Add(MobPosition + new Cp(i, i));
        }
        for (int i = 1; MobPosition.x - i >= 0 && MobPosition.y + i < 8; i++)
        {
            movelist.Add(MobPosition + new Cp(-i, i));
        }
        for (int i = 1; MobPosition.x + i < 8 && MobPosition.y - i >= 0; i++)
        {
            movelist.Add(MobPosition + new Cp(i, -i));
        }
        for (int i = 1; MobPosition.x - i >= 0 && MobPosition.y - i >= 0; i++)
        {
            movelist.Add(MobPosition + new Cp(-i, -i));
        }
        Cp target = movelist[Random.Range(0, movelist.Count)];
        Moveatk(target, 0.5f);
    }

    private void atk1()
    {
        for (int i = 1; MobPosition.x + i < 8 && MobPosition.y + i < 8; i++)
        {
            atk(MobPosition + new Cp(i, i), 0.5f);
        }
        for (int i = 1; MobPosition.x - i >= 0 && MobPosition.y + i < 8; i++)
        {
            atk(MobPosition + new Cp(-i, i), 0.5f);
        }
        for (int i = 1; MobPosition.x + i < 8 && MobPosition.y - i >= 0; i++)
        {
            atk(MobPosition + new Cp(i, -i), 0.5f);
        }
        for (int i = 1; MobPosition.x - i >= 0 && MobPosition.y - i >= 0; i++)
        {
            atk(MobPosition + new Cp(-i, -i), 0.5f);
        }
    }
}