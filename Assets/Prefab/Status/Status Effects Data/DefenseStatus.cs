using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatusEffect
{
    public class DefenseStatus : Base
    {
        public DefenseStatus(string name, int duration, float baseInstensity, float ratioIntensity, float chance, int type) : base(name, duration, baseInstensity, ratioIntensity, chance, type)
        {
        }

        public override void ApplyEffect(Character.Base chara)
        {
            
            Debug.Log("This chara kena Defense Status");
            chara.health.curDef += baseInstensity;
        }

        public override void RemoveEffect(Character.Base chara)
        {
            chara.health.curDef += baseInstensity;
        }

        public override void HandleEffectPerTurn(Character.Base chara)
        {
            //Ini Buat DoT
            //health.curDef -= intensity;
        }
    }


}
