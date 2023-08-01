using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class MelodicResonance : BardSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        //print(skillOwner);
        //print(ally[selfPos]);
        //float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        //Debug.Log("berhasil calculate");

        //Heal all ally
        //Attack last two row enemy
        //Debug.Log(ally.Length);
        for (int i = 0; i < ally.Length; i++)
        {
            ally[i].health.Heal(ally[i].health.hp * 0.2f);
            Debug.Log("Heal " + ally[i].name + " sebesar " + ally[i].health.hp * 0.2f);
        }

        //Debug.Log("Heal " + ally[targetPos].name + " sebesar " + ally[targetPos].health.hp * 0.2f);
        //Debug.Log(targetPos);

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
