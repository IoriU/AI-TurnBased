using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

namespace Character {
    public class Skill : MonoBehaviour
    {
        //Attack prop.
        public float atk; //Initial / base attack from character
        private float curAtk; //Dynamic stat of attack
        //List skill yang dimiliki oleh character
        public global::Skill[] skills;
       
        // Start is called before the first frame update
        void Start()
        {
            curAtk = atk;

            Base character = transform.GetComponent<Base>();
            for (int i = 0; i < skills.Length; i++)
            {
                global::Skill skill = Instantiate(skills[i], transform).GetComponent<global::Skill>();
                skill.SetSkillOwner(character, i);
            }
        }
    }

}
