using StatusEffect;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class PrecisionArrow : ArcherSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        //print(skillOwner);
        //print(ally[selfPos]);
        //Debug.Log("berhasil calculate");

        //Apply Stun Effect Tes to Self
        skillOwner.GetComponent<Character.StatusEffectManager>().ApplyStatusEffect(new StunStatus("stun-1", 3, 0f,0f, 1f,-1));
        enemy[targetPos].seManager.ApplyStatusEffect(new ChargingStatus("charging", 6, 500,0, 1.0f, -1));

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
