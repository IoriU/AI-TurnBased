using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flurry : FencerSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        enemy[targetPos].TakeDamage(helper[0].baseValue + skillOwner.atk * helper[0].statRatio);
        enemy[targetPos].TakeDamage(helper[1].baseValue + skillOwner.atk * helper[1].statRatio);
        enemy[targetPos].TakeDamage(helper[2].baseValue + skillOwner.atk * helper[2].statRatio);

        //Applied Status Effect
        StatusEffect insEffect = Instantiate(status);
        enemy[targetPos].ApplyEffect(insEffect);

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override Character[] GetTargetSelection(Character[] teams)
    {
        return new Character[] { teams[0], teams[teams.Length - 1] };
    }
}