using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : FencerSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        //print(skillOwner);
        //print(ally[selfPos]);
        ResetTarget();
        float damage = skillOwner.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        //Debug.Log("berhasil calculate");
        enemy[targetPos].health.TakeDamage(damage);


        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        float damage = skillOwner.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        enemy[targetPos].health.TakeDamage(damage);
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }


    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return new Character.Base[] { teams[0] };
    }
}