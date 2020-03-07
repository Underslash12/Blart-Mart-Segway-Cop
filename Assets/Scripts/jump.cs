using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class jump : MonoBehaviour
{
    private bool grounded = true;
    private bool canStillJump = false;
    private bool sControl;
    private long startedJumpingAt;
    private GameObject player;
    private Rigidbody2D rb;
    private float oGravity;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        rb = player.GetComponent<Rigidbody2D>();
        oGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        // controls jump
        if (Input.GetKey("space")) {
            Vector2 v = rb.velocity;
            if (grounded) {
                grounded = false;
                canStillJump = true;
                startedJumpingAt = Now();

                rb.gravityScale = 0;
                rb.velocity = new Vector2(v.x, 7.5f);
            }
            else if (canStillJump && Now() - startedJumpingAt > 400) {
                canStillJump = false;
                rb.gravityScale = oGravity;
            }
        }
        if (Input.GetKeyUp("space")) {
            canStillJump = false;
            rb.gravityScale = oGravity;
        }

        // controls "s" code
        if (grounded) {
            if (Input.GetKey("s") && !sControl)  {
                print("1");
                sControl = true;
                Physics2D.IgnoreLayerCollision(8, 8, true);
                //lastSTime = Now();
            }
        }
        //if (Input.GetKeyUp("s")) {
        //    print("2");
        //    //StartCoroutine(ExecuteAfterTime(0.1f));
        //    Physics2D.IgnoreLayerCollision(8, 8, false);
        //}

    }

    //void FixedUpdate()
    //{
    //    // loops through each floor contact point, creates a raycast down, 
    //    // and checks whether or not it collides with the ground
    //    // if it does, the player is grounded
    //    for (int i = 1; i <= 3; i++) {
    //        if (Physics2D.Raycast(player.transform.GetChild(i).transform.position, -Vector2.up, 0.1f) != false) {
    //            grounded = true;
    //            continue;
    //        }
    //    }
    //}

    long Now()
    {
        return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        print("here");
        yield return new WaitForSeconds(time);
        print("and here");
        //if (Now() - lastSTime > time * 1000) {
        Physics2D.IgnoreLayerCollision(8, 8, false);
        //}
    }

    void OnCollisionStay2D(Collision2D c)
    {        
        if ((c.gameObject.tag == "floor" || c.gameObject.tag == "box") && rb.velocity.y == 0) {
            grounded = true;
        }

    }

    void OnCollisionExit2D (Collision2D c)
    {
        grounded = false;
        if (sControl) {
            sControl = false;
            StartCoroutine(ExecuteAfterTime(0.2f));
        }
       
    }
}