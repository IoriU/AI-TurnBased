using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatusEffect
{
    public class SpeedStatus : Base
    {
        public SpeedStatus(string name, int duration, float intensity, float chance) : base(name, duration, intensity, chance)
        {
        }

        public override void ApplyEffect(Character.Base chara)
        {
            
            Debug.Log("This chara kena Speed Status");
            chara.speed.curSpeed += intensity;
        }

        public override void RemoveEffect(Character.Base chara)
        {
            chara.speed.curSpeed -= intensity;
        }

        public override void HandleEffectPerTurn(Character.Base chara)
        {
            //Ini Buat DoT
            //health.curDef -= intensity;
        }
    }


}
