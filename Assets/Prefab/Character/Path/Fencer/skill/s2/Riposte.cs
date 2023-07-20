using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatusEffect;

public class Riposte : FencerSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        //print(skillOwner);
        //print(ally[selfPos]);
        ResetTarget();
        Character.StatusEffectManager seManager = skillOwner.GetComponent<Character.StatusEffectManager>();
        seManager.ApplyStatusEffect(new Counter("counter", 1, 0, 0, 1f, 1));
        seManager.ApplyStatusEffect(new DefenseStatus("counter_def", 1, 0, 0.2f, 1, 1));
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {

        float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        enemy[targetPos].health.TakeDamage(damage);
        enemy[targetPos].seManager.ApplyStatusEffect(new StunStatus("stun", 1, 0, 0, 0.8f, -1));
        skillOwner.speed.BoostSpeedBar(0.2f);
    }


    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return new Character.Base[] { skillOwner.GetComponent<Character.Base>() };
    }
}
