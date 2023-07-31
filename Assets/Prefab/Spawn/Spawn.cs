using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    // posisi spawn
    public Transform[] spawnPoses;
    public GameObject[] spawnObjs;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnObjs.Length; i++)
        {
            Instantiate(spawnObjs[i], spawnPoses[i]);
        }
    }
}
