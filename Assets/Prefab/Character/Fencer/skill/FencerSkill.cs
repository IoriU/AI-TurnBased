using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencerSkill : Skill
{
    private int target;
    public Skill basic;

    private void Start()
    {
        target = -1;
    }

    public void ActivateSkill(int selfPos, int targetPos, Character[] ally, Character[] enemy)
    {
        if (target == targetPos)
        {
            basic.UniqueSkill(0, targetPos, null, null);
        }
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }
}
