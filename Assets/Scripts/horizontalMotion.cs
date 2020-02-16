using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class horizontalMotion : MonoBehaviour
{
    private float speed = 10;
    private float fuelPerSecond = 1;
    private float fuelMod = 1;
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
        if (Input.GetKey("space") && !moving) {
            startMovement();
        }
        if (moving) {
            string p = "Sprites/";
            if (Input.GetKey("a")) {
                rb.velocity = new Vector2(speed * 0.75f, rb.velocity.y);
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(p + slow);
                spr.sprite = slowS;
                fuelMod = 1;
            }
            if (Input.GetKey("d")) {
                rb.velocity = new Vector2(speed * 1.25f, rb.velocity.y);
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(p + fast);
                spr.sprite = fastS;
                fuelMod = 1.5f;
            }

            if (Input.GetKeyUp("a")) {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(p + norm);
                spr.sprite = normS;
                fuelMod = 1;
            }
            if (Input.GetKeyUp("d")) {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(p + norm);
                spr.sprite = normS;
                fuelMod = 1;
            }
        }
    }

    void FixedUpdate()
    {

        if (moving) {
            this.GetComponent<textController>().updateFuel(-1 * fuelPerSecond * fuelMod / 60);
            this.GetComponent<textController>().updateBS(-1f * 1 / 60);
        }
        
    }

    void startMovement()
    {
        moving = true;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
