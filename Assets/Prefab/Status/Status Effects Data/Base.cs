using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace StatusEffect {
    public class Base
    {

        public string name;
        public int duration;
        public float baseInstensity;
        public float ratioInstensity;
        public float chance;
        public int type;

        //Type -1 = Debuff
        //Type 0 = Unique
        //Type 1 = Buff
        public Base(string name, int duration, float baseInstensity, float ratioIntensity, float chance, int type)
        {
            this.name = name;
            this.duration = duration;
            this.baseInstensity = baseInstensity;
            this.ratioInstensity = ratioIntensity;
            this.chance = chance;
            this.type = type;
        }

        //Create abstract function to apply effect
        public virtual void ApplyEffect(Character.Base chara)
        { }
        public virtual void RemoveEffect(Character.Base chara)
        { }
        public virtual void HandleEffectPerTurn(Character.Base chara) { }

        public virtual void HandleEffectOnTurn(Character.Base chara) { }
    }

}
