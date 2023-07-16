using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
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

    //Button buat apa njirrr
    public Button button;
    
    //Setup/Init Character
    void Start()
    {
        this.curHp = hp;
        this.hpBar.InitValue(hp);
        this.curAtk = atk;
        this.curDef = def;
        this.curSpeed = speed;
        this.speedBarObj.InitValue(100);
    }

    void Update()
    {
        //BATTLESTATE check
        if (battleState == BattleState.TURN)
        {
            //Masih Testing kah
            if (Input.GetKeyDown(KeyCode.Space))
            {
                speedBar = 0;
                battleState = BattleState.IDLE;
                GameController.instance.battleState = GameController.BattleState.LOOP;
            }
        }
    }

    //Ganti Battle State Character
    public void YourTurn()
    {
        battleState = BattleState.TURN;
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
        curHp -= damage;
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
}
