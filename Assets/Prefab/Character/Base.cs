using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


namespace Character
{
    public class Base : MonoBehaviour
    {
        //BATTLE STATE FOR CHARACTER
        public enum BattleState
        {
            IDLE,
            TURN
        }

        //Value untuk menyimpan state pada character => IDLE or Turn
        public BattleState battleState;

        //NAMING CHARACTER, EX: Fencer, archer, bard, or manymnay moar
        public string name;
        public int pos;
        private Health health;
        private Speed speed;
        private Skill skill;


        //Setup/Init Character
        void Start()
        {

            health = GetComponent<Health>();
            speed = GetComponent<Speed>();
            skill = GetComponent<Skill>();

        }

        void Update()
        {
            //BATTLESTATE check
            if (battleState == BattleState.TURN)
            {
                //Masih Testing kah
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameController.instance.battleState = GameController.BattleState.LOOP;
                }
            }
        }

        //Ganti Battle State Character
        public void YourTurn()
        {
            battleState = BattleState.TURN;
        }

        public void NextTurn()
        {
            speed.NextTurn();
            battleState = BattleState.IDLE;
        }

        


        public void AddStatus(float val)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveStatus(float val)
        {
            throw new System.NotImplementedException();
        }
    }

}
