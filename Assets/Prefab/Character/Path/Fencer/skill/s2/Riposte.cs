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
        seManager.ApplyStatusEffect(new Counter("counter", 1, 0f, 1f));
        seManager.ApplyStatusEffect(new DefenseStatus("counter_def", 1, 0.2f, 1f));
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {

        float damage = skillOwner.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        enemy[targetPos].health.TakeDamage(damage);
        // enemy[targetPos].GetComponent<Character.StatusEffectManager>().ApplyStatusEffect(new stun);
        skillOwner.speed.BoostSpeedBar(0.2f);
    }


    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return new Character.Base[] { skillOwner.GetComponent<Character.Base>() };
    }
}
