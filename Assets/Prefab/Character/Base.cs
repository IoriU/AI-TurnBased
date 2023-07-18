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
        //NAMING CHARACTER, EX: Fencer, archer, bard, or manymnay moar
        public string name;
        public int pos;
        public Health health;
        public Speed speed;
        public Skill skill;

        //Status Effect Manager
        public StatusEffectManager seManager;

        //Setup/Init Character
        void Start()
        {

            health = GetComponent<Health>();
            speed = GetComponent<Speed>();
            skill = GetComponent<Skill>();
            seManager = GetComponent<StatusEffectManager>();
        }



    }

}
