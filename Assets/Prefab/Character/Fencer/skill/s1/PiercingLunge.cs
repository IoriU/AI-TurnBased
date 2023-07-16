using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingLunge : FencerSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        enemy[targetPos].TakeDamage(helper[0].baseValue + skillOwner.atk * helper[0].statRatio, 0);
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        enemy[targetPos].TakeDamage(helper[0].baseValue + skillOwner.atk * helper[0].statRatio, 0);
    }

    public override Character[] GetTargetSelection(Character[] teams)
    {
        return new Character[] { teams[0] };
    }
}