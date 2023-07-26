using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardSkill : Skill
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
        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }
}
