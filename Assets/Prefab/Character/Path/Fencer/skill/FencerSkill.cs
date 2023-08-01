using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencerSkill : Skill
{

    public Character.Fencer path;

    public override void Start()
    {
        path = (Fencer)skillOwner.path;
        base.Start();
    }

    protected void ResetTarget()
    {
        path.target = -1;
        path.curHit = 1;
        path.ignoreS2 = true;
    }

    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        if (path.ignoreS2)
        {
            path.ignoreS2 = false;
        } else if (path.target == targetPos)
        {
            
            for (int i = 0; i < path.curHit; i++)
            {
                skillOwner.skill.skills[0].UniqueSkill(0, targetPos, ally, enemy);
                print("follow up " + i);
            }
            
            if (path.curHit < path.maxHit)
            {
                path.curHit++;
            }
        }
        else
        {
            path.target = targetPos;
        }
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }
}
