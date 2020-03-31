using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float NormalSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(NormalSpeed * Input.GetAxis("Horizontal") * Time.deltaTime,
        NormalSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("dead");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("deadd");
    }
}
