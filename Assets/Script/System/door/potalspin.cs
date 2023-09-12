using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potalspin : Util
{
    private float k = 0;
    private void FixedUpdate()
    {
        k += 15 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, k);
    }
}
