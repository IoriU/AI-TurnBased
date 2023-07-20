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
        public float intensity;
        public float chance;

        public Base(string name, int duration, float intensity, float chance)
        {
            this.name = name;
            this.duration = duration;
            this.intensity = intensity;
            this.chance = chance;

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
