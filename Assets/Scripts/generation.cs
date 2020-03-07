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
    public GameObject candy;
    public GameObject fuel;

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
            if (r.Next(0, 3) < 2) {
                int x = (int) r.Next(0, 4);
                if (hasPlatforms[x]) {
                    i -= 1;
                    continue;
                } else {
                    hasPlatforms[x] = true;
                    if (lastStart != null) {
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
        setPlatforms (starting, length, position);
    }

    void setPlatforms (int[] start, int[] length, float position)
    {
        for (int i = 0; i < start.Length; i++) {
            if (length[i] > 0) {
                float y = i * 3 - 5 + 0.5f;
                Quaternion q = new Quaternion(0, 0, 0, 0);
                //for (int j = 0; j < length[i]; j++) {
                //    Instantiate(center, new Vector3(position + 24 + start[i] + j, y, 0), q);
                //}
                GameObject t = Instantiate(center, new Vector3(position + 24 + start[i] + length[i] / 2, y, 0), q);
                t.GetComponent<SpriteRenderer>().size = new Vector2(0.08f * length[i], 0.08f);

                if (length[i] > 7 && r.Next(0, 4) == 1) {
                    Instantiate(box, new Vector3(position + 24 + start[i] + length[i] - 1 - r.Next(1, 5), y + 1.5f, 0), q);
                } else if (r.Next(0, 10) == 0) {
                    if (r.Next(0, 2) == 0) {
                        Instantiate(candy, new Vector3(position + 24 + start[i] + length[i] - 1 - r.Next(1, 5), y + 1.5f, 0), q);
                    }
                    else {
                        Instantiate(fuel, new Vector3(position + 24 + start[i] + length[i] - 1 - r.Next(1, 5), y + 2.5f, 0), q);
                    } 
                }
            }
        }
    }
}
