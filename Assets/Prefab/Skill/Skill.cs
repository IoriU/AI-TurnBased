using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill : MonoBehaviour
{
    //NAMING SKIL, EX: Thrust, Arrow Rain, Heal, or manymnay moar
    public string name;

    //Stat for skill cooldown
    public Character skillOwner;
    public int skillPos;

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

    //Add Status Effect
    public StatusEffect status;

    // Give character and position of skill



    // sama kaya start manual
    public void SetSkillOwner(Character chr, int pos)
    {
        curCd = 0;
        curUse = 0;
        skillOwner = chr;
        skillPos = pos;
        if (nextEvo)
        {
            nextEvo.SetSkillOwner(chr, pos);
        }
        Debug.Log("selesai set owner");
        
    }
    
    //Jalankan skill
    public virtual void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)

    {
        //Set and adding exp for skill to evo
        curCd = cd;
        curUse++;
        //Statement for checking skill ready for evo or not
        if (useToEvo > 0 && curUse == useToEvo)
        {
            //print("harusnya evo");
            ally[selfPos].skill[skillPos] = nextEvo;
            //skillOwner.skill[skillPos] = nextEvo; // skill evolusi
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

