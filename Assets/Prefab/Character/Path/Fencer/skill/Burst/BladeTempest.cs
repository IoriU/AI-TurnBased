using StatusEffect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTempest : Skill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        //print(skillOwner);
        //print(ally[selfPos]);
        float damage;
        for (int i = 0; i < 20; i++)
        {
            damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
            int target = Random.Range(0, 4);
            enemy[target].health.TakeDamage(damage);
            if (Random.Range(0f, 1f) < 0.5f)
            {
                enemy[target].speed.AbsorbSpeedBar(20f);
            }
        }
    }

    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return teams;
    }
}
