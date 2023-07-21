using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatusEffect
{
    public class ChargingStatus : Base
    {
        public ChargingStatus(string name, int duration, float baseInstensity, float ratioIntensity, float chance, int type) : base(name, duration, baseInstensity, ratioIntensity, chance, type)
        {
        }

        public override void ApplyEffect(Character.Base chara)
        {
            Debug.Log("Applied Charge Status to this Chara: " + chara.name);
        }

        public override void RemoveEffect(Character.Base chara)
        {
            Debug.Log("This Character get FullCharge attack from Archer: " + chara.name);

            chara.health.TakeDamage(baseInstensity, 0);
        }

        public override void HandleEffectPerTurn(Character.Base chara)
        {

        }

        public override void HandleEffectOnTurn(Character.Base chara)
        {
            
        }
    }


}
