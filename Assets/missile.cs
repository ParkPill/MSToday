using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public Vector2 Target;
    public float Speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        int which = UnityEngine.Random.Range(0, 4);
        float y = UnityEngine.Random.Range(-6, 6);
        float x = UnityEngine.Random.Range(-11, 11);
        if (which == 0)
        {
            y = 6;
            Target = new Vector2(UnityEngine.Random.Range(-11, 11), -6);
        }
        else if (which == 1)
        {
            x = 11;
            Target = new Vector2(-11, UnityEngine.Random.Range(-6, 6));
        }
        else if (which == 2)
        {
            y = -6;
            Target = new Vector2(UnityEngine.Random.Range(-11, 11), 6);
        }
        else if (which == 3)
        {
            x = -11;
            Target = new Vector2(11, UnityEngine.Random.Range(-6, 6));
        }
        transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(-2 * Time.deltaTime, -1 * Time.deltaTime, 0f);
        float step = Speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, Target, step);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    
    {
        Debug.Log("hit");
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hitt");
    }
}




