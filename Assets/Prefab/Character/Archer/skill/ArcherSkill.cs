using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkill : Skill
{
    private int target;

    private void Start()
    {
        target = -1;
    }

    protected void ResetTarget()
    {
        target = -1;
    }

    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        if (target == targetPos)
        {
            target++;
            for (int i = 0; i < target; i++)
            {
                skillOwner.skills[0].UniqueSkill(0, targetPos, ally, enemy);
                print("follow up " + i);
            }
        }
        else
        {
            target = targetPos;
        }
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }
}
