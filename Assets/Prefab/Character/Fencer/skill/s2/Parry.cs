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

        skillOwner.GetComponent<Character.StatusEffectManager>().ApplyStatusEffect(new Counter("counter", 3, 0f, 1f));

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }



    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return new Character.Base[] { skillOwner.GetComponent<Character.Base>() };
    }
}