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
    public SkillEnum.Target target;
    public SkillEnum.TargetType targetType;
    public Effect[] effects;

    private void Start()
    {
        effects = GetComponents<Effect>();
    }




}

