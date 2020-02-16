using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalMotion : MonoBehaviour
{
    private float speed = 10;
    private Rigidbody2D rb;
    private bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p")) {
            startMovement();
        }
        if (moving) {
            if (Input.GetKey("a")) {
                rb.velocity = new Vector2(speed * 0.75f, rb.velocity.y);
            }
            if (Input.GetKey("d")) {
                rb.velocity = new Vector2(speed * 1.25f, rb.velocity.y);
            }

            if (Input.GetKeyUp("a")) {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            if (Input.GetKeyUp("d")) {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
    }

    void startMovement()
    {
        moving = true;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
