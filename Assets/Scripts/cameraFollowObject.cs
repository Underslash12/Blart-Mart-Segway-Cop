﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowObject : MonoBehaviour
{

    private GameObject followTarget;
    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(followTarget.transform.position.x + 4, transform.position.y, transform.position.z);
        transform.position = pos;
    }
}
