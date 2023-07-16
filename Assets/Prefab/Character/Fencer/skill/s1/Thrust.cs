using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : FencerSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        enemy[targetPos].TakeDamage(helper[0].baseValue + skillOwner.atk * helper[0].statRatio);
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        enemy[targetPos].TakeDamage(helper[0].baseValue + skillOwner.atk * helper[0].statRatio);
    }

    public override Character[] GetTargetSelection(Character[] teams)
    {
        return new Character[] { teams[0] };
    }
}
