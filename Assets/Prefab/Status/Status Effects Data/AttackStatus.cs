using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatusEffect
{
    public class AttackStatus : Base
    {
        public AttackStatus(string name, int duration, float baseInstensity, float ratioIntensity, float chance, int type) : base(name, duration, baseInstensity, ratioIntensity, chance, type)
        {
        }

        public override void ApplyEffect(Character.Base chara)
        {
            
            Debug.Log("This chara kena Attack Status");
            chara.skill.curAtk += baseInstensity;
        }

        public override void RemoveEffect(Character.Base chara)
        {
            chara.skill.curAtk -= baseInstensity;
        }

        public override void HandleEffectOnTurn(Character.Base chara)
        {
            //base.HandleEffectOnTurn(chara);
        }

        public override void HandleEffectPerTurn(Character.Base chara)
        {
            //Ini Buat DoT
            //health.curDef -= intensity;
        }
    }


}
