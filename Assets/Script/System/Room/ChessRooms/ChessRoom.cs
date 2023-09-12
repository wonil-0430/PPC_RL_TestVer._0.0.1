using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessRoom : Room
{
    public GameObject[,] chesspan = new GameObject[8, 8];
    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                chesspan[i, j] = null;
            }
        }
    }

}
