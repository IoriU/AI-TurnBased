using StatusEffect;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class Thrust : FencerSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        
        float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        enemy[targetPos].health.TakeDamage(damage);

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue / 3, helper[0].statRatio / 3);
        enemy[targetPos].health.TakeDamage(damage);
    }


    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return new Character.Base[] { teams[0] };
    }
}
