using StatusEffect;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniqueEffect
{
    public class BleedingPlus : Base
    {
        Character.Base chara;
        public override void SetupTrigger(Character.Base chara)
        {
            StatusEffect.Base oldEffect;
            StatusEffect.BleedingStatusPlus oldBleeding = null;
            this.chara = chara;

            if (chara.seManager.effects.TryGetValue("bleeding-plus", out oldEffect))
            {
                //parse parent class to child class
                oldBleeding = (BleedingStatusPlus)oldEffect;
                //Debug.Log("Harusnya nyetak ini: " + oldBleeding.name);
                oldBleeding.bleedingTriggered.AddListener(OnTrigger);
            }
            

            //chara.health.takeDamageEvent.AddListener(OnTrigger);
            Debug.Log("Sucess setup Bleeding Plus \n" + chara.name);
        }

        public void OnTrigger(StatusEffect.BleedingStatusPlus status)
        {
            GameController gameController = GameController.instance;
            int thisCharaTurnIndex = Array.IndexOf(gameController.teams2, chara);

            int targetIndex = thisCharaTurnIndex; // The index you want to access
            int adjacentElementsCount = 1; // Number of adjacent elements on each side

            // Calculate the lower and upper bounds for the adjacent elements
            int lowerBound = Math.Max(targetIndex - adjacentElementsCount, 0);
            int upperBound = Math.Min(targetIndex + adjacentElementsCount, gameController.teams2.Length - 1);

            //Apply BleedingStatus to adjacent enemie/s
            for (int i = lowerBound; i < targetIndex; i++)
            {
                Debug.Log($"Adjacent element at index {i}: {gameController.teams2[i]}");
                gameController.teams2[i].seManager.ApplyStatusEffect(new BleedingStatus("bleeding-bp", 6, 200, 0, 1, -1));
                //gameController.teams2[i].health.TakeDamage(300, 1.0f);
            }
            for (int i = targetIndex + 1; i <= upperBound; i++)
            {
                Debug.Log($"Adjacent element at index {i}: {gameController.teams2[i]}");
                gameController.teams2[i].seManager.ApplyStatusEffect(new BleedingStatus("bleeding-bp", 3, 200, 0, 1, -1));
            }
            //gameController.teams2[targetIndex].seManager.ApplyStatusEffect(new BleedingStatus("bleeding-bp", 3, 300, 0, 1f, 0));

            //Debug.Log("INI HARUSNYA ADA NJIR");


        }

        
    }

}
