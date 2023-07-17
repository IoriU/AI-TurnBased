using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : FencerSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        ;
        //ResetTarget();
        //Applied Status Effect
        StatusEffect insEffect = Instantiate(status);
        enemy[targetPos].ApplyEffect(insEffect);

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override Character[] GetTargetSelection(Character[] teams)
    {
        return new Character[] { teams[0]};
    }
}