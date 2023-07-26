using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.PlayerSettings;
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

    // sama kaya start manualz

    public virtual void Start()
    {
        curCd = 0;
        curUse = 0;
        if (nextEvo == null)
        {
            curCd = cd;
        }
    }
    public void SetSkillOwner(Character.Base chr, int pos)
    {
        skillOwner = chr;
        skillPos = pos;

    }

    //Jalankan skill
    public virtual void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)

    {
        curCd = cd;
        curUse++;
        if (nextEvo && curUse == useToEvo)
        {
            //print("harusnya evo");
            skillOwner.skill.Evolution(nextEvo, skillPos);
        }
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
