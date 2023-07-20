using StatusEffect;
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
        skillOwner.seManager.ApplyStatusEffect(new Counter("counter", 1, 0f, 1f, 1));
        skillOwner.seManager.ApplyStatusEffect(new DefenseStatus("counter_def", 1, 0.2f, 1f, 1));
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        
        float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        enemy[targetPos].health.TakeDamage(damage);
        skillOwner.speed.BoostSpeedBar(0.2f);
    }


    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return new Character.Base[] { skillOwner.GetComponent<Character.Base>() };
    }
}