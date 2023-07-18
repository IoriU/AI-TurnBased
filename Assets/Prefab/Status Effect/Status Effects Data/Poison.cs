using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : StatusEffect
{
    public Poison(StatusEffectType type, int duration, int intensity) : base(type, duration, intensity)
    {
    }

    public override void ApplyEffect(Character.Base chara)
    {
        //Debug.Log("This chara kena poison");
        chara.health.curDef -= intensity;
        //Debug.Log(chara.name);
    }

    public override void RemoveEffect(Character.Base chara)
    {
        chara.health.curDef += intensity;
    }

    public override void HandleEffectPerTurn(Character.Base chara)
    {
        //Ini Buat DoT
        //health.curDef -= intensity;
    }
}

