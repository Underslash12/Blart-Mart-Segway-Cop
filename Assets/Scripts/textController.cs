using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textController : MonoBehaviour
{
    // Start is called before the first frame update

    public Text distance;
    public Text bloodSugar;
    private float bsNum = 100;
    public Text fuel;
    private float fuelNum = 100;
    private Rigidbody2D rb;

    void Start()
    {

        rb = GameObject.Find("player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance.text = "Distance: " + (int)(rb.position.x * 10) / 10f + "m"; 
        bloodSugar.text = "BS: " + (int)(bsNum * 10) / 10f + "%";
        fuel.text = "Charge: " + (int)(fuelNum * 10) / 10f + "%";
    }

    public void updateBS (float bs)
    {
        print(bsNum + " " + bs);
        bsNum += bs;
        if (bsNum > 100) bsNum = 100;
        if (bsNum < 0) bsNum = 0;
    }

    public void updateFuel (float fl)
    {
        fuelNum += fl;
        if (fuelNum > 100) fuelNum = 100;
        if (fuelNum < 0) fuelNum = 0;
    }
}
