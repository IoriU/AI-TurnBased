using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour, IEffectting
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
    
    //Health prop.
    public float hp; //Initial / base hp from character
    private float curHp; //Current hp after taking some damage or get some heal
    public ProgressBar hpBar; //For UI purpose
    //Attack prop.
    public float atk; //Initial / base attack from character
    private float curAtk; //Dynamic stat of attack
    //Defence prop.
    public float def; //Initial / base defence from character
    private float curDef; //Dynamic stat of defence
    //Speed prop
    public float speed; //Initial / base speed from character
    private float curSpeed; //Dynamic stat of defence
    //Bagian dari prop speed yang nentuin dia bakal jalan di turn tersebut atau tidak,
    //Ex, bila speedBar lebih dari 100, maka chara tersebut akan jalan.
    public float speedBar;
    public ProgressBar speedBarObj; //For UI Purpose
    public float barRatio; 
   
    //List skill yang dimiliki oleh character
    public Skill[] skill;

    //List Status Effect
    List<StatusEffect> effects = new List<StatusEffect>();
    //Status Effect Counter Stat
    public bool isStun = false;
    //Setup/Init Character
    void Start()
    {

        curHp = hp;
        hpBar.InitValue(hp);
        curAtk = atk;
        curDef = def;
        curSpeed = speed;
        speedBarObj.InitValue(100);
        for (int i = 0; i < skill.Length; i++)
        {
            skill[i].SetSkillOwner(this, i);
        }

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
        //Debug.Log("This Player Turn: " + this.name);
        if(!this.isStun)
        {
            battleState = BattleState.TURN;
        } else
        {
            Debug.Log("Ini chara kena stun coy");
        }
        
    }

    public void NextTurn()
    {
        //Handle Status Effect
        if(effects.Count != 0)
        {
            HandleEffect();
        }
        
        speedBar = 0;
        speedBarObj.UpdateVal(speedBar);
        battleState = BattleState.IDLE;
    }

    //Update character SpeedBar tiap turn selesai, nanti dipanggil di GameController
    //Interval parameter untuk getGameDeltaTime
    public void UpdateSpeedBar(float interval)
    {
        speedBar += curSpeed * interval * barRatio;
        speedBarObj.UpdateVal(speedBar);
    }

    public void TakeDamage(float val)
    {
        TakeDamage(val, 0.8f);
    }

    public void TakeDamage(float val, float defRatio)
    {
        float damage = val - defRatio * 0.8f;
        //Debug.Log(string.Format("{0} take {1} damages.", name, damage));
        curHp -= damage;
        
        hpBar.UpdateVal(curHp);
    }

    public void Heal(float val)
    {
        throw new System.NotImplementedException();
    }

    public void AddStatus(float val)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveStatus(float val)
    {
        throw new System.NotImplementedException();
    }

    public void ApplyEffect(StatusEffect effect)
    {
        Debug.Log("Applied Status to this character: " + this.name);

            
        this.atk += effect.atk;
        this.def += effect.def;
        this.speed += effect.speed;

        //Cek Stun Momen
        if(this.isStun)
        {
            Debug.Log("This karakter already kena stun");
            effect.isStun = false;
            effect.duration = 0;
        } else
        {
            this.isStun = effect.isStun;
        }
        

        effects.Add(effect);
    }

    public void RemoveEffect(StatusEffect effect)
    {
        this.atk -= effect.atk;
        this.def -= effect.def;
        this.speed -= effect.speed;
        this.speedBar -= effect.speedBar;
        this.isStun = false;

        effect.Destroy();
        effects.Remove(effect);
        
    }

    public void HandleEffect()
    {

        foreach(StatusEffect effect in effects)
        {
            if (effect.currentDuration >= effect.duration)
            {
                //Cek apakah Effect memiliki Stun
                if (this.isStun)
                {
                    this.isStun = false;
                }

                //HAPUSS SEMUA EFFEK
                RemoveEffect(effect);
            }
            else
            {
                

                //Check if this Status had Dot
                this.curHp += effect.dot;
                hpBar.UpdateVal(curHp);

                //Add Duration to Status
                effect.currentDuration += 1;
            }
            
        }   
    }
        
}
