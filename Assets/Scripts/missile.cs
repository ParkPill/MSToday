using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public Vector3 Target;
    public float Speed = 2;
    public GameScript TheGameScript;
    public Vector2 LeftBottom;
    public Vector2 RightTop;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public void Init()
    {
        int which = UnityEngine.Random.Range(0, 4);
        float y = UnityEngine.Random.Range(LeftBottom.y, RightTop.y);
        float x = UnityEngine.Random.Range(LeftBottom.x, RightTop.x);
        if (which == 0)
        {
            y = RightTop.y;
            Target = new Vector3(UnityEngine.Random.Range(LeftBottom.x, RightTop.x), LeftBottom.y);
        }
        else if (which == 1)
        {
            x = RightTop.x;
            Target = new Vector3(LeftBottom.x, UnityEngine.Random.Range(LeftBottom.y, RightTop.y));
        }
        else if (which == 2)
        {
            y = LeftBottom.y;
            Target = new Vector3(UnityEngine.Random.Range(LeftBottom.x, RightTop.x), RightTop.y);
        }
        else if (which == 3)
        {
            x = LeftBottom.x;
            Target = new Vector3(RightTop.x, UnityEngine.Random.Range(LeftBottom.y, RightTop.y));
        }
        transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
  public void Move() {
        if (TheGameScript.IsGameOver)
        {
            return;
        }
        //transform.Translate(-2 * Time.deltaTime, -1 * Time.deltaTime, 0f);
        float step = Speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, Target, step);

        if (transform.position == Target)
        {
            Destroy(gameObject);
        }
    }
       
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}




