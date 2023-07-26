using Character;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace StatusEffect
{
    public class BleedingStatusPlus : Base
    {
        private UniqueEffect.BleedingPlus bleedingPlus;
        // Subskreb
        public UnityEvent<BleedingStatusPlus> bleedingTriggered = new UnityEvent<BleedingStatusPlus>();
        public BleedingStatusPlus(string name, int duration, float baseInstensity, float ratioIntensity, float chance, int type) : base(name, duration, baseInstensity, ratioIntensity, chance, type)
        {
        }

        public override void ApplyEffect(Character.Base chara)
        {
            chara.seManager.ApplyStatusEffect(new BleedingStatus("bleeding-bp", 4, 250, 0, 1f, 0));
            Debug.Log("This chara kena Bleeding Plus: " + chara.name);
            
        }

        public override void RemoveEffect(Character.Base chara)
        {          
            Object.Destroy(bleedingPlus);
        }

        public override void HandleEffectPerTurn(Character.Base chara)
        {
            //Ini Buat DoT
            bleedingPlus = chara.seManager.root.AddComponent<UniqueEffect.BleedingPlus>();
            bleedingPlus.SetupTrigger(chara);

            Debug.Log("BleedingPlus DoT on: " + chara.name);
            //chara.health.TakeDamage(baseInstensity, 1.0f);
            //Debug.Log("Status Effect Name: " + this.name);
            bleedingTriggered.Invoke(this);
        }
    }


}
