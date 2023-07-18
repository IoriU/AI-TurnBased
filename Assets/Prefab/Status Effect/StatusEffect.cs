using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;


public enum StatusEffectType
{
    None,
    Poison,
    Burn,
    Freeze,
    AtkUp,
    DefUp,
    Heal,
}

public class StatusEffect 
{
    public StatusEffectType type;
    public int duration;
    public int intensity;


    public StatusEffect(StatusEffectType type, int duration, int intensity)
    {
        this.type = type;
        this.duration = duration;
        this.intensity = intensity;
    }

    //Create abstract function to apply effect
    public virtual void ApplyEffect(Character.Base chara)
    { }
    public virtual void RemoveEffect(Character.Base chara)
    { }
    public virtual void HandleEffectPerTurn(Character.Base chara) { }
}
