﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float NormalSpeed = 3;
    public GameScript ThaGameScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ThaGameScript.IsGameOver)
        {
            return;
        }

        transform.Translate(NormalSpeed * Input.GetAxis("Horizontal") * Time.deltaTime,
        NormalSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name.Contains("ms")) 
        {
            ThaGameScript.GameOver();
        }
        else if (collision.gameObject.name.Contains("Coin"))
        {
            ThaGameScript.AddInGameCoin(collision.gameObject.GetComponent<Coin>().Count);
            Destroy(collision.gameObject);
        }
    }
}
