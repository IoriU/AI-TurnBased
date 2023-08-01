using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniqueEffect
{
    public class Counter : Base
    {
        public Skill skill;
        public override void SetupTrigger(Character.Base chara)
        {
            
            chara.health.takeDamageEvent.AddListener(OnTrigger);
            Debug.Log("Sucess setup \n" + chara.name);
        }

        public override void OnTrigger(Character.Base chara)
        {
            
            GameController gameController = GameController.instance;
            (Character.Base[] ally, Character.Base[] enemy) = gameController.GetCurrentAllyEnemy();
            Debug.Log("FULL COUNTER dari " + chara.name + " ke " + ally[gameController.charaTurn.pos]);
            if (chara != gameController.charaTurn)
            {
                skill.UniqueSkill(0, gameController.charaTurn.pos, enemy, ally);
            }
            
        }

        
    }

}
