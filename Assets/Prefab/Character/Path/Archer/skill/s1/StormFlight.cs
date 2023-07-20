using StatusEffect;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class StormFlight : ArcherSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        //print(skillOwner);
        //print(ally[selfPos]);

        float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        //Debug.Log("berhasil calculate");

        //Attack last two row enemy
        for (int i = enemy.Length - 2; i < enemy.Length; i++)
        {
            enemy[i].health.TakeDamage(damage);
            enemy[i].seManager.ApplyStatusEffect(new BleedingStatus("bleeding-2f", 3, 200, 0, 0.75f, -1));
            //Debug.Log("Hit For " + enemy[i].name);
        }


        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        enemy[targetPos].health.TakeDamage(damage);
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }


    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return new Character.Base[] { teams[teams.Length-1], teams[teams.Length-2] };
    }
}
