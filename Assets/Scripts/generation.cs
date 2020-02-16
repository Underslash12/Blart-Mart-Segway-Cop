using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class generation : MonoBehaviour
{

    private GameObject player;
    private float lastGenPoint = -8;
    System.Random r = new System.Random();
    private int[] lastLength = null;
    private int[] lastStart = null;

    public GameObject edgeL;
    public GameObject edgeR;
    public GameObject center;
    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > lastGenPoint) {
            gen(lastGenPoint + 8);
            lastGenPoint += 8;
        }
    }

    void gen(float position)
    {
        bool[] hasPlatforms = new bool[4];
        int[] length = new int[4];
        int[] starting = new int[4];
        for (int i = 0; i < 4; i++) {
            //if (r.Next(0, (int) Math.Pow(2, (int) (i / 2))) == 0) {
            if (r.Next(0, 3) < 2) {
                //print("A");
                //print(i);
                int x = (int) r.Next(0, 4);
                if (hasPlatforms[x]) {
                    //print("B");
                    i -= 1;
                    continue;
                } else {
                    //print("C");
                    hasPlatforms[x] = true;
                    if (lastStart != null) {
                        //print("D");
                        int sx = r.Next(0, 16);
                        int sl = r.Next(6, 14);
                        if ((lastStart[x] + lastLength[x]) % 16 >= sx) {
                            hasPlatforms[x] = false;
                            continue;
                        }
                        else {
                            starting[x] = sx;
                            length[x] = sl;
                        }
                    }
                }
            }
        }
        lastLength = length;
        lastStart = starting;
        //print(starting);
        //print(length);
        //print("\n" + string.Join("\n", starting));
        foreach (int i in starting) {
            print(i + " " + position + "\n");
        }
        //print("\n" + string.Join("\n", length));
        setPlatforms (starting, length, position);
    }

    void setPlatforms (int[] start, int[] length, float position)
    {
        for (int i = 0; i < start.Length; i++) {
            if (length[i] > 0) {
                float y = i * 3 - 5 + 0.5f;
                Quaternion q = new Quaternion(0, 0, 0, 0);
                Instantiate(edgeL, new Vector3(position + 24 + start[i], y, 0), q);
                for (int j = 0; j < length[i] - 2; j++) {
                    Instantiate(center, new Vector3(position + 24 + start[i] + j + 1, y, 0), q);
                }
                Instantiate(edgeR, new Vector3(position + 24 + start[i] + length[i] - 1, y, 0), q);
                if (length[i] > 7 && r.Next(0, 4) == 1) {
                    Instantiate(box, new Vector3(position + 24 + start[i] + length[i] - 1 - r.Next(1, 5), y + 1.5f, 0), q);
                }
            }
        }
    }
}
