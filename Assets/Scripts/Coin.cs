using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : missile
{
    public int Count = 1;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
