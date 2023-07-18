using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;  

namespace Character
{
    public class StatusEffectManager : MonoBehaviour
    {
        //public Dictionary<StatusEffect.BaseType, int> effectTimers = new Dictionary<StatusEffect.BaseType, int>();
        
        /*public List<StatusEffect.Base> effects = new List<StatusEffect.Base>();*/
        public Dictionary<string, StatusEffect.Base> effects = new Dictionary<string, StatusEffect.Base>();
        //List<StatusEffect.Base> removeEffects = new List<StatusEffect.Base>();
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
            foreach(StatusEffect.Base eff in effects.Values)
           
            {
                if (eff.duration <= 0)
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
                
                //Debug.Log(effects);
            }      
            
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
