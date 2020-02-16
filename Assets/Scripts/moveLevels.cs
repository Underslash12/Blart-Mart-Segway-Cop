using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLevels : MonoBehaviour
{

    private GameObject camera;
    private bool moving;
    private float x;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        camera = GameObject.FindWithTag("MainCamera");
        x = 0;
        // i = 0;
    }
    
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag == "bottomCollider"){
            if(moving){
                transform.position += new Vector3(0.0f, 0.45f, 0.0f);
            } else {
                moving = true;
                x = -10/19f;
            }
        }
        if(coll.gameObject.tag == "topCollider"){
            if(moving){
                transform.position += new Vector3(0.0f, -0.45f, 0.0f);
            } else {
                moving = true;
                x = 10/19f;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moving){
           if(i < 19){
                camera.transform.position += new Vector3(0.0f, x, 0.0f);
                i++;
            } else {
                i = 0;
                moving = false;
                if(x > 0){
                    transform.position += new Vector3(0.0f, 1f, 0.0f);
                    GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 10f), ForceMode2D.Impulse);
                }
            } 
        }       
    }
}
