using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace StatusEffect
{
    public class Counter : Base
    {
        private UniqueEffect.Counter counter;
        public Counter(string name, int duration, float baseInstensity, float ratioIntensity, float chance, int type) : base(name, duration, baseInstensity, ratioIntensity, chance, type)
        {
        }

        public override void ApplyEffect(Character.Base chara)
        {
            counter = chara.seManager.root.AddComponent<UniqueEffect.Counter>();
            counter.SetupTrigger(chara);
        }

        public override void RemoveEffect(Character.Base chara)
        {
            Object.Destroy(counter);
        }

        public override void HandleEffectPerTurn(Character.Base chara)
        {
            //Ini Buat DoT
            //health.curDef -= intensity;
        }
    }
}

