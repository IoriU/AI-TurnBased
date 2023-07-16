using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    //NAMING SKIL, EX: Thrust, Arrow Rain, Heal, or manymnay moar
    public string name;
    //Stat for skill cooldown
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

    //Jalankan skill
    public void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        curCd = cd;
        curUse++;
        if (useToEvo < 0 && curUse == useToEvo)
        {
            int idx = Array.IndexOf(ally[targetPos].skill, this);
            ally[targetPos].skill[idx] = nextEvo; // skill evolusi
        }
    }

    public void UniqueSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    { 
        ;
    }

    public Character[] GetTargetSelection(Character[] teams)
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

