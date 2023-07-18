using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatusEffect
{
    public class Poison : Base
    {
        public Poison(string name, int duration, float intensity, float chance) : base(name, duration, intensity, chance)
        {
        }

        public override void ApplyEffect(Character.Base chara)
        {
            
            Debug.Log("This chara kena poison");
            chara.health.curDef -= intensity * chara.health.def;
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


}
