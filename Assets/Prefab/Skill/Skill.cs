using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class Skill : MonoBehaviour
{
    //NAMING SKIL, EX: Thrust, Arrow Rain, Heal, or manymnay moar
    public string name;

    //Stat for skill cooldown
    public Character.Base skillOwner;
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

    // Give character and position of skill

    // sama kaya start manual
    public void SetSkillOwner(Character.Base chr, int pos)
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
    public virtual void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)

    {
        curCd = cd;
        curUse++;
        if (useToEvo > 0 && curUse == useToEvo)
        {
            print("harusnya evo");
            /*ally[selfPos].skill[skillPos] = nextEvo;*/
            //skillOwner.skill[skillPos] = nextEvo; // skill evolusi
        }
    }

    public float GachaDamage(float damage)
    {
        return Random.Range(damage * 0.85f, damage * 1.15f);
    }

    public virtual void UniqueSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        ;
    }

    public virtual Character.Base[] GetTargetSelection(Character.Base[] teams)
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
