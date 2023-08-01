using StatusEffect;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class HarmoniousHymn: BardSkill
{
    public override void ActivateSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {
        //print(skillOwner);
        //print(ally[selfPos]);
        //float damage = skillOwner.skill.CalculateDamage(helper[0].baseValue, helper[0].statRatio);
        //Debug.Log("berhasil calculate");

        //Heal all ally (BASE)
        for (int i = 0; i < ally.Length; i++)
        {
            ally[i].health.Heal(ally[i].health.hp * 0.2f);
            //Debug.Log("Heal " + ally[i].name + " sebesar " + ally[i].health.hp * 0.2f);
            //EVO EFFECT ADD ATTACK UP STATUS EFFECT
            ally[i].seManager.ApplyStatusEffect(new AttackStatus("attackUp-1f", 4, 5, 0, 1f, -1));
            //ABAIKAN INI 
            /*if (ally[i].statusEffect.Find(x => x.statusEffectName == "Attack Up") == null)
            {
                StatusEffect.StatusEffect attackUp = new StatusEffect.StatusEffect();
                attackUp.statusEffectName = "Attack Up";
                attackUp.statusEffectDescription = "Increase Attack by 20%";
                attackUp.icon = Resources.Load<Sprite>("UI/StatusEffectIcon/AttackUp");
                attackUp.duration = 3;
                attackUp.effectType = StatusEffect.EffectType.Buff;
                attackUp.effectMethod = StatusEffect.EffectMethod.Add;
                attackUp.stats = new StatusEffect.StatusEffect.Stat(0, 0, 0, 0, 0, 0, 0, 0, 0, 0.2f, 0, 0, 0, 0, 0, 0, 0);
                ally[i].statusEffect.Add(attackUp);
            }
            else
            {
                ally[i].statusEffect.Find(x => x.statusEffectName == "Attack Up").duration = 3;
            }  */

        }



        //Debug.Log("Heal " + ally[targetPos].name + " sebesar " + ally[targetPos].health.hp * 0.2f);
        //Debug.Log(targetPos);

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }

    public override void UniqueSkill(int selfPos, int targetPos, Character.Base[] ally, Character.Base[] enemy)
    {

        base.ActivateSkill(selfPos, targetPos, ally, enemy);
    }


    public override Character.Base[] GetTargetSelection(Character.Base[] teams)
    {
        return teams;
    }
}
