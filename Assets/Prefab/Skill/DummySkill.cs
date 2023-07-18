using StatusEffect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySkill : Skill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        enemy[targetPos].health.TakeDamage(1);

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return new Character.Base[] { teams[0] };
    }
}
