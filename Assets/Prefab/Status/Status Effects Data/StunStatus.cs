using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatusEffect
{
    public class StunStatus : Base
    {
        public StunStatus(string name, int duration, float baseInstensity, float ratioIntensity, float chance, int type) : base(name, duration, baseInstensity, ratioIntensity, chance, type)
        {
        }

        public override void ApplyEffect(Character.Base chara)
        {
            Debug.Log("Applied Stun Status to this Chara: " + chara.name);

        }

        public override void RemoveEffect(Character.Base chara)
        {
            
        }

        public override void HandleEffectPerTurn(Character.Base chara)
        {
            
        }

        public override void HandleEffectOnTurn(Character.Base chara) {
            Debug.Log("This chara kena Stun Status: " + duration);
            GameController gameController = GameController.instance;
            gameController.NextTurn();
        }
    }


}
