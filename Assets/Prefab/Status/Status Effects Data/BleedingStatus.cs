using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatusEffect
{
    public class BleedingStatus : Base
    {
        public BleedingStatus(string name, int duration, float intensity, float chance, int type) : base(name, duration, intensity, chance, type)
        {
        }

        public override void ApplyEffect(Character.Base chara)
        {
            Debug.Log("This chara kena Bleeding: " + chara.name);
        }

        public override void RemoveEffect(Character.Base chara)
        {
            
        }

        public override void HandleEffectPerTurn(Character.Base chara)
        {
            //Ini Buat DoT
            Debug.Log("Bleeding DoT on: " + chara.name + ", for " + intensity);
            chara.health.TakeDamage(intensity, 1.0f);
        }
    }


}
