using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    //NAMING SKIL, EX: Thrust, Arrow Rain, Heal, or manymnay moar
    public string name;

//Stat for skill cooldown
    protected Character skillOwner;
    protected int skillPos;

    public int cd;
    private int curCd;
    //EXP needed for skill Evo
    public int useToEvo;
    public int curUse;
    //Ref to next evo skill, ex: Arrow Rain evo-> Arrow Rain II
    public Skill nextEvo;
    //Skill-nya nargetin temen, musuh, atau self
    public SkillEnum.Target targetTeam;
    //Ini gatau apa njirr
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
    
//Jalankan skill
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
        return teams;
    }

    [System.Serializable]
    public struct StatHelper
    {
        public float baseValue;
        public float statRatio;
    }


}

