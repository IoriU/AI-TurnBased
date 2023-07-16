using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riposte : FencerSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        ;
        ResetTarget();
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override Character[] GetTargetSelection(Character[] teams)
    {
        return new Character[] { skillOwner };
    }
}