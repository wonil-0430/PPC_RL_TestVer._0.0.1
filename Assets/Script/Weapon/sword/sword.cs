using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : Util
{
    private void Awake()
    {
        GetComponent<Animation>().Play("Sw");
    }

}
