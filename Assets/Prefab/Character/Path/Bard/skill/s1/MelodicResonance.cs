using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class MelodicResonance : ArcherSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        //print(skillOwner);
        //print(ally[selfPos]);
        //float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        //Debug.Log("berhasil calculate");

        //Heal one ally
        //ally[targetPos].health.Heal(ally[targetPos].health.hp * 0.2f);

        Debug.Log("Heal " + ally[targetPos].name + " sebesar " + ally[targetPos].health.hp * 0.2f);

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }


    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return teams;
    }
}
