using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatusEffect
{
    public class CritDamageStatus : Base
    {
        public CritDamageStatus(string name, int duration, float intensity, float chance) : base(name, duration, intensity, chance)
        {
        }

        public override void ApplyEffect(Character.Base chara)
        {
            
            Debug.Log("This chara kena CritRate Status");
            chara.skill.critDamage += intensity;
        }

        public override void RemoveEffect(Character.Base chara)
        {
            chara.skill.critDamage -= intensity;
        }

        public override void HandleEffectPerTurn(Character.Base chara)
        {
            //Ini Buat DoT
            //health.curDef -= intensity;
        }
    }


}
