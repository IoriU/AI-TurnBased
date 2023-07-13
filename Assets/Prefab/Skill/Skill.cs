using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string name;
    public int cd;
    private int curCd;
    public int useEvo;
    public int curUse;
    public Skill nextEvo;
    public Effect[] effects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public struct Effect
{
    public EffectEnum type;
    public int baseVal;
    public string stat;
    public float ratio;
    public string target;
    public bool isAoe;
}

