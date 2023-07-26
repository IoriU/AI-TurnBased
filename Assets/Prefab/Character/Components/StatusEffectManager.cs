using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
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

        public bool RemoveStatusEffect(int type)
        {
            return RemoveStatusEffect(type, effects.Count);
        }

        public bool RemoveStatusEffect(int type, int k)
        {
            // Temp nama buat dihapus
            List<string> deletedKey = new List<string>();

            foreach (KeyValuePair<string, StatusEffect.Base> pair in effects)
            {
                string key = pair.Key;
                StatusEffect.Base eff = pair.Value;

                // Check buff atau debuff
                if (eff.type == type)
                {
                    deletedKey.Add(key);
                    // Kalau udah k dihapus, maka break
                    if (k-- == 0) break;
                }
            }

            foreach (string key in deletedKey)
            {
                RemoveEffect(effects[key]);
                // hapus dari dictionary
                effects.Remove(key);
            }

            // Kalau ada yg dihapus, maka retrun True
            return deletedKey.Count > 0 ? true : false;
        }


        public void ApplyStatusEffect(StatusEffect.Base effect)
        {
           // Gacha check
            if (Random.Range(0f, 1f) < effect.chance)
            {
                
                StatusEffect.Base oldEffect;
                //Add Status Effect to the list
                
                // cek apakah buff nya udah ada atau belum
                if (effects.TryGetValue(effect.name, out oldEffect))
                {
                    // cek lebih lama durasi yang mana
                    if (oldEffect.duration > effect.duration)
                    {
                        RemoveEffect(oldEffect);
                        //Trigger Status Effect
                        effect.ApplyEffect(GetComponent<Base>());
                        effects.Add(effect.name, effect);

                    } else
                    {
                        Debug.Log("Status yg sebelumnya masih tegang");
                    }
                } else 
                {
                        //Trigger Status Effect
                        effect.ApplyEffect(GetComponent<Base>());
                        effects.Add(effect.name, effect);
                }
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

        public void HandleEffectEndTurn()
        {

            ;
        }

        public void HandleEffectOnTurn()
        {
            // list temporary buat catet yg mau dihapus
            List<string> deletedKey = new List<string>();
            // Update the status effect timers           
            foreach (KeyValuePair<string, StatusEffect.Base> pair in effects)
            {
                string key = pair.Key;
                StatusEffect.Base eff = pair.Value;

                if (eff.duration <= 0)
                {
                    // catet key yg udah abis durasi
                    deletedKey.Add(key);
                }
                else
                {
                    //Kurangi durasi effect
                    eff.duration--;

                    //Jalankan effect per turn
                    eff.HandleEffectPerTurn(this.GetComponent<Base>());
                }

                //Debug.Log(effects);
            }
            // hapus yg durasinya 0
            foreach (string key in deletedKey)
            {
                RemoveEffect(effects[key]);
                // hapus dari dictionary
                effects.Remove(key);
            }
        }

        
    }


}
