using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "candy"){
            GameObject.FindWithTag("Player").GetComponent<textController>().updateBS(10);
        }
        if(collider.gameObject.tag == "fuel"){
            GameObject.FindWithTag("Player").GetComponent<textController>().updateFuel(10);
        }
        Destroy(collider.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
