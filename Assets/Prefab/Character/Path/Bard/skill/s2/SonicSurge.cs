using Character;
using StatusEffect;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class SonicSurge: BardSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        print(skillOwner);
        //print(ally[selfPos]);
        //float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        //Debug.Log("berhasil calculate");

        //Heal all ally
        //Attack last two row enemy
        //Debug.Log(ally.Length);
        ally = GameController.instance.teams1;
        Character.Base lowAtkChr = null;

        //Find lowest attack from ally
        for (int i = 0; i < ally.Length; i++)
        {
            if (ally[i] != skillOwner)
            {
                if (lowAtkChr == null)
                {
                    lowAtkChr = ally[i];
                }
                else
                {
                    if (ally[i].skill.curAtk < lowAtkChr.skill.curAtk)
                    {

                        lowAtkChr = ally[i];
                    }
                }
            }
            
        }
        //Apply ataack up status effect to lowest attack ally
        lowAtkChr.seManager.ApplyStatusEffect(new AttackStatus("attackUp-2f", 6, 10, 0, 1f, -1));
        //Damage one enemy
        enemy[targetPos].health.TakeDamage(100);

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }


    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return teams;
    }
}
