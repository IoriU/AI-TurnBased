using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Character
{
    public class StatusEffectManager : MonoBehaviour
    {
        //public Dictionary<StatusEffectType, int> effectTimers = new Dictionary<StatusEffectType, int>();
        
        public List<StatusEffect> effects = new List<StatusEffect>();
        //List<StatusEffect> removeEffects = new List<StatusEffect>();
        public void ApplyStatusEffect(StatusEffect effect)
        {
            //Trigger Status Effect
            effect.ApplyEffect(this.GetComponent<Base>());
            //Add Status Effect to the list
            effects.Add(effect);
        }

        public void RemoveEffect(StatusEffect status)
        {
            Base chr = this.GetComponent<Base>();
            status.RemoveEffect(chr);
            effects.Remove(status);
        }

        public void HandleEffectTimer()
        {
            // Update the status effect timers           
            foreach(StatusEffect eff in effects)
            {
                  if (eff.duration <= 0)
                {
                    RemoveEffect(eff);
                    //break;
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

}
