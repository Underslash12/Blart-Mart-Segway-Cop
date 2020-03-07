using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rainbowOutline : MonoBehaviour
{

    Outline o;

    // Start is called before the first frame update
    void Start()
    {
        o = this.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        float h, s, v;
        Color.RGBToHSV(o.effectColor, out h, out s, out v);
        o.effectColor = Color.HSVToRGB(h + 0.001f, s, v);
    }
}
