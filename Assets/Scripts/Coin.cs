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
        // 게임 끝나고 나서 나오게 만들기
        // 게임 끝나고 멈추게 만들기
    }
}
