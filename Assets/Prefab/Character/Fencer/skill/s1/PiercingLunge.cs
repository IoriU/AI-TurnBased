using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingLunge : FencerSkill
{
    public new void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        enemy[targetPos].TakeDamage(helper[0].baseValue + skillOwner.atk * helper[0].statRatio, 0);
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public new void UniqueSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        enemy[targetPos].TakeDamage(helper[0].baseValue + skillOwner.atk * helper[0].statRatio, 0);
    }

    public new Character[] GetTargetSelection(Character[] teams)
    {
        return new Character[] { teams[0] };
    }
}