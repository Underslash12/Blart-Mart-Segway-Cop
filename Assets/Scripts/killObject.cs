using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "box" && this.GetComponent<Rigidbody2D>().velocity.x == 0){
            SceneManager.LoadScene("gameover");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
