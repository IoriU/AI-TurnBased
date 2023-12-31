using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

namespace Character {
    public class Skill : MonoBehaviour
    {
        //Attack prop.
        public float atk; //Initial / base attack from character
        [HideInInspector]
        public float curAtk; //Dynamic stat of attack
        //List skill yang dimiliki oleh character
        public global::Skill[] skills;
        public Transform skillsRoot;

        public float critChance = 0.15f;
        public float critDamage = 1.5f;

        private Base chara;


        // Start is called before the first frame update
        void Start()
        {
            curAtk = atk;
            chara = GetComponent<Base>();
            for (int i = 0; i < skills.Length; i++)
            {

                global::Skill skill = Instantiate(skills[i], skillsRoot).GetComponent<global::Skill>();
                skill.SetSkillOwner(chara, i);
                skills[i] = skill;
            }
            
        }

        public void Evolution(global::Skill evoSkill, int pos)
        {
            global::Skill skill = Instantiate(evoSkill, skillsRoot).GetComponent<global::Skill>();
            skill.SetSkillOwner(chara, pos);
            Destroy(skills[pos].gameObject);
            skills[pos] = skill;
        }

        public float GachaDamage(float damage)
        {
            //Debug.Log("start gacha damage");
            return Random.Range(damage * 0.85f, damage * 1.15f);
        }

        public float GachaCrit(float damage)
        {
            //Debug.Log("start gacha crit");
            if (Random.Range(0f, 1f) < critChance)
            {
                return damage * critDamage;
            }
            //Debug.Log("finish gacha damage");
            return damage;
        }

        public float CalculateDamage(float baseAtk, float ratioAtk)
        {
            float damage = baseAtk + ratioAtk * curAtk;
            damage = GachaDamage(damage);
            //Debug.Log("finish gacha damage");
            return GachaCrit(damage);

        }

        public void NextTurn()
        {
            foreach (global::Skill skill in skills)
            {
                skill.ReduceCooldown();
            }
        }
    }

}
