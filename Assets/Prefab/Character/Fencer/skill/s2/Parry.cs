using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : FencerSkill
{
    public new void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        ;
        ResetTarget();
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public new Character[] GetTargetSelection(Character[] teams)
    {
        return new Character[] { skillOwner };
    }
}