using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flurry : FencerSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        float damage = 0;
        for (int i = 0; i < 3; i++)
        {
            damage = skillOwner.skill.CalculateDamage(helper[i].baseValue, helper[i].statRatio);
            enemy[targetPos].health.TakeDamage(damage);
            if (Random.Range(0f, 1f) < 0.2f)
            {
                enemy[targetPos].speed.AbsorbSpeedBar(10f);
            }
        }
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return new Character.Base[] { teams[0] };
    }
}
