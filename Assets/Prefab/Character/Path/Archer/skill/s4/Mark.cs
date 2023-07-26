using StatusEffect;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class  Mark : ArcherSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);

        //Mark One Enemy
        enemy[targetPos].seManager.ApplyStatusEffect(new MarkStatus("Mark", 2, 0, 0, 1, -1));
        
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
