using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;  

namespace Character
{
    public class StatusEffectManager : MonoBehaviour
    {
        //public Dictionary<StatusEffect.BaseType, int> effectTimers = new Dictionary<StatusEffect.BaseType, int>();
        
        public Dictionary<string, StatusEffect.Base> effects = new Dictionary<string, StatusEffect.Base>();

        public Transform root;
        public void ApplyStatusEffect(StatusEffect.Base effect)
        {
           // Gacha check
            if (Random.Range(0f, 1f) < effect.chance)
            {
                
                StatusEffect.Base oldEffect;
                //Add Status Effect to the list
                if (effects.TryGetValue(effect.name, out oldEffect))
                {
                    RemoveEffect(oldEffect);
                }
                //Trigger Status Effect
                effect.ApplyEffect(GetComponent<Base>());
                effects.Add(effect.name, effect);

            } else
            {
                Debug.Log("MAMPUS MISS");
            }
            
        }
        

        public void RemoveEffect(StatusEffect.Base status)
        {
            Base chr = this.GetComponent<Base>();
            status.RemoveEffect(chr);
            effects.Remove(status.name);
        }

        public void HandleEffectTimer()
        {
            // Update the status effect timers
            //Create for loop to get effects.Values

            /*for(int i = 0; i < effects.Count; i++)
            {
                StatusEffect.Base eff = effects.Values.ElementAt(i);

                if(eff.duration <= 0)
                {
                    RemoveEffect(eff);
                    break;
                } else
                {
                    //Kurangi durasi effect
                    eff.duration--;

                    //Jalankan effect per turn
                    eff.HandleEffectPerTurn(this.GetComponent<Base>());
                }
            }  */

            List<StatusEffect.Base> effectValues = effects.Values.ToList();

            foreach (StatusEffect.Base eff in effectValues)
            {
                if (eff.duration <= 0)
                {
                    RemoveEffect(eff);
                }
                else
                {
                    eff.duration--;
                    eff.HandleEffectPerTurn(this.GetComponent<Base>());
                }
            }
        }

        public void HandleEffectOnTurn()
        {

            List<StatusEffect.Base> effectValues = effects.Values.ToList();

            foreach (StatusEffect.Base eff in effectValues)
            {
                eff.HandleEffectOnTurn(this.GetComponent<Base>());
            }

            for (int i = 0; i < effects.Count; i++)
            {
                StatusEffect.Base eff = effects.Values.ElementAt(i);
                eff.HandleEffectOnTurn(this.GetComponent<Base>());
            }


            /*foreach (StatusEffect.Base eff in effects.Values)
            {
                eff.HandleEffectOnTurn(this.GetComponent<Base>());
            }*/
        }

        
    }

    public class EffectDict
    {
        int duration;
        StatusEffect.Base status;
        UniqueEffect.Base unique;

        public EffectDict(int duration, StatusEffect.Base status, UniqueEffect.Base unique)
        {
            this.duration = duration;
            this.status = status;
            this.unique = unique;
        }
    }

}
