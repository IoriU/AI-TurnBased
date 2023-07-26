using StatusEffect;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class DeepWound : ArcherSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);

        //Attack last two row enemy
        for (int i = enemy.Length - 2; i < enemy.Length; i++)
        {
            enemy[i].seManager.ApplyStatusEffect(new BleedingStatus("bleeding-2f", 3, 200,0, 0.75f, -1));

        }

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }


    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return new Character.Base[] { teams[teams.Length - 1], teams[teams.Length - 2] };
    }
}
