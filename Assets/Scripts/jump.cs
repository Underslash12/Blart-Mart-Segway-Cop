using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class jump : MonoBehaviour
{
    private bool grounded = true;
    private bool canStillJump = false;
    private long startedJumpingAt;
    private Rigidbody2D rb;
    private float oGravity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("player").GetComponent<Rigidbody2D>();
        oGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space")) {
            Vector2 v = rb.velocity;
            if (grounded) {
                rb.velocity = new Vector2(v.x, 7.5f);
                grounded = false;
                canStillJump = true;
                startedJumpingAt = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                rb.gravityScale = 0;
            }
            else if (canStillJump && DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - startedJumpingAt > 400) {
                canStillJump = false;
                rb.gravityScale = oGravity;
            }
        }
        if (Input.GetKeyUp("space")) {
            canStillJump = false;
            rb.gravityScale = oGravity;
        }
    }

    void OnCollisionStay2D (Collision2D c)
    {
        if ((c.gameObject.tag == "floor" || c.gameObject.tag == "box") && rb.velocity.y == 0) {
            grounded = true;
        }
    }

    void OnCollisionExit2D (Collision2D c)
    {
        grounded = false;
    }
}