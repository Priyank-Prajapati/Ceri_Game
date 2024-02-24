using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    private bool dirRight = true;
    public float speed = 3.0f;
    public float rightPosition = 4.0f;
    public float leftPosition = -4.0f;  

    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= rightPosition)
        {
            dirRight = false;
            transform.localScale = new Vector2(transform.localScale.x - (transform.localScale.x * 2), transform.localScale.y);
        }

        if (transform.position.x <= leftPosition)
        {
            dirRight = true;
            transform.localScale = new Vector2(transform.localScale.x - (transform.localScale.x * 2), transform.localScale.y);
        }
    }
}
