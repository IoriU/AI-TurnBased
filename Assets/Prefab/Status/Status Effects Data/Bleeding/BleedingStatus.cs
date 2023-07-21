using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatusEffect
{
    public class BleedingStatus : Base
    {
        public BleedingStatus(string name, int duration, float baseInstensity, float ratioIntensity, float chance, int type) : base(name, duration, baseInstensity, ratioIntensity, chance, type)
        {
        }

        public override void ApplyEffect(Character.Base chara)
        {
            Debug.Log("This chara kena Bleeding: " + chara.name);
            //chara.health.TakeDamage(300, 1.0f);
        }

        public override void RemoveEffect(Character.Base chara)
        {
            
        }

        public override void HandleEffectPerTurn(Character.Base chara)
        {
            //Ini Buat DoT
            Debug.Log("Bleeding DoT on: " + chara.name + ", for " + baseInstensity);
            chara.health.TakeDamage(baseInstensity, 1.0f);
        }
    }


}
