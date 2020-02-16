using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class horizontalMotion : MonoBehaviour
{
    private float speed = 10;
    private Rigidbody2D rb;
    private bool moving = false;

    private Animator anim;
    private SpriteRenderer spr;
    public string slow;
    public Sprite slowS;
    public string norm;
    public Sprite normS;
    public string fast;
    public Sprite fastS;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("player").GetComponent<Rigidbody2D>();
        anim = GameObject.Find("player").GetComponent<Animator>();
        spr = GameObject.Find("player").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p")) {
            startMovement();
        }
        if (moving) {
            string p = "Sprites/";
            //print(p);
            if (Input.GetKey("a")) {
                rb.velocity = new Vector2(speed * 0.75f, rb.velocity.y);
                //anim.runtimeAnimatorController = Resources.Load(p + slow) as RuntimeAnimatorController;
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(p + slow);
                spr.sprite = slowS;
            }
            if (Input.GetKey("d")) {
                rb.velocity = new Vector2(speed * 1.25f, rb.velocity.y);
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(p + fast);
                spr.sprite = fastS;
            }

            if (Input.GetKeyUp("a")) {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                print(Resources.Load<RuntimeAnimatorController>(p + norm));
                print(p + norm);
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(p + norm);
                spr.sprite = normS;
            }
            if (Input.GetKeyUp("d")) {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(p + norm);
                spr.sprite = normS;
            }
        }
    }

    void startMovement()
    {
        moving = true;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
