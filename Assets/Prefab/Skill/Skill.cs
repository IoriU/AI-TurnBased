using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string name;
    protected Character skillOwner;
    protected int skillPos;
    public int cd;
    private int curCd;
    public int useToEvo;
    public int curUse;
    public Skill nextEvo;
    public SkillEnum.Target targetTeam;
    public StatHelper[] helper;

     // Give character and position of skill
    public void SetSkillOwner(Character chr, int pos)
    {
        skillOwner = chr;
        skillPos = pos;
        if (nextEvo)
        {
            nextEvo.SetSkillOwner(chr, pos);
        }
        
    }

    public virtual void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        curCd = cd;
        curUse++;
        if (useToEvo < 0 && curUse == useToEvo)
        {
            skillOwner.skill[skillPos] = nextEvo; // skill evolusi
        }
    }

    public virtual void UniqueSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    { 
        ;
    }

    public virtual Character[] GetTargetSelection(Character[] teams)
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

