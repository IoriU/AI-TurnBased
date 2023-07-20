using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniqueEffect
{
    public class Charging : Base
    {
        public override void SetupTrigger(Character.Base chara)
        {
            
            chara.health.takeDamageEvent.AddListener(OnTrigger);
            Debug.Log("Sucess setup \n" + chara.name);
        }

        public override void OnTrigger(Character.Base chara)
        {
            
            GameController gameController = GameController.instance;
            (Character.Base[] ally, Character.Base[] enemy) = gameController.GetCurrentAllyEnemy();
            Debug.Log("FULL COUNTER dari " + chara.name + " ke " + ally[gameController.charTurn.pos]);
            if (chara != gameController.charTurn)
            {
                chara.skill.skills[0].UniqueSkill(0, gameController.charTurn.pos, enemy, ally);
            }
            
        }

        
    }

}
