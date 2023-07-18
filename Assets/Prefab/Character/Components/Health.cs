using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Health : MonoBehaviour
    {
        //Health prop.
        public float hp; //Initial / base hp from character
        private float curHp; //Current hp after taking some damage or get some heal
        public ProgressBar hpBar; //For UI purpose

        //Defence prop.
        public float def; //Initial / base defence from character
        [HideInInspector]
        public float curDef; //Dynamic stat of defence

        // Start is called before the first frame update
        void Start()
        {
            curHp = hp;
            hpBar.InitValue(hp);
            curDef = def;
        }

        public void TakeDamage(float val)
        {
            TakeDamage(val, 0.8f);
        }

        public void TakeDamage(float val, float defRatio)
        {
            float damage = val - defRatio * curDef;
            //Debug.Log(string.Format("{0} take {1} damages.", name, damage));
            curHp -= damage;

            hpBar.UpdateVal(curHp);
        }

        public void Heal(float val)
        {
            throw new System.NotImplementedException();
        }
    }

}
