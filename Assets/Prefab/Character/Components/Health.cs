using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class Health : MonoBehaviour
    {
        //Health prop.
        public float hp; //Initial / base hp from character
        [HideInInspector]
        public float curHp; //Current hp after taking some damage or get some heal
        public ProgressBar hpBar; //For UI purpose

        //Defence prop.
        public float def; //Initial / base defence from character
        [HideInInspector]
        public float curDef; //Dynamic stat of defence

        // Subskreb
        public UnityEvent<Base> takeDamageEvent = new UnityEvent<Base>();

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
            takeDamageEvent.Invoke(GetComponent<Base>());
        }

        public void Heal(float val)
        {
            //implement heal function
            curHp += val;
            if (curHp > hp)
            {
                curHp = hp;
            }
            hpBar.UpdateVal(curHp);


        }
    }

}
