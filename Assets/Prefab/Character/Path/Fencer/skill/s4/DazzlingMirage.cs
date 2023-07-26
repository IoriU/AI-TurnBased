using StatusEffect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DazzlingMirage : FencerSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {

        float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        enemy[targetPos].health.TakeDamage(damage);

        if (enemy[targetPos].seManager.RemoveStatusEffect(1, 1))
        {
            enemy[targetPos].seManager.ApplyStatusEffect(new StunStatus("stun", 1, 0, 0, 0.8f, -1));
        }
        else
        {
            Debug.Log("GOBLOK MISS");
        }

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }


    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return new Character.Base[] { teams[0] };
    }
}
