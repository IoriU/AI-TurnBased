using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string name;
    public int cd;
    private int curCd;
    public int useToEvo;
    public int curUse;
    public Skill nextEvo;
    public SkillEnum.Target targetTeam;
    public StatHelper[] helper;

    public void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        curCd = cd;
        curUse++;
        if (curUse >= useToEvo)
        {
            ; // skill evolusi
        }
    }

    public void UniqueSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    { 
        ;
    }

    public Character[] GetTargetSelection(Character[] teams)
    {
        return null;
    }

    [System.Serializable]
    public struct StatHelper
    {
        public float baseValue;
        public float statRatio;
    }


}

