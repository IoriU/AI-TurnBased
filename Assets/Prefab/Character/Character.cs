using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public enum BattleState
    {
        Idle,
        Turn
    }

    public string name;
    public float hp;
    private float curHp;
    public ProgressBar hpBar;
    public float atk;
    private float curAtk;
    public float def;
    private float curDef;
    public float speed;
    private float curSpeed;
    public float speedBar;
    public ProgressBar speedBarObj;
    public float barRatio;
    public BattleState battleState;

    public Skill[] skill;

    public Button button;
    
    void Start()
    {
        curHp = hp;
        hpBar.InitValue(hp);
        curAtk = atk;
        curDef = def;
        curSpeed = speed;
        speedBarObj.InitValue(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (battleState == BattleState.Turn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                speedBar = 0;
                battleState = BattleState.Idle;
                GameController.instance.battleState = GameController.BattleState.Loop;
            }
        }
    }

    public void YourTurn()
    {
        battleState = BattleState.Turn;
    }

    public void UpdateSpeedBar(float interval)
    {
        speedBar += curSpeed * interval * barRatio;
        speedBarObj.UpdateVal(speedBar);
    }

    public void TakeDamage(float val)
    {
        throw new System.NotImplementedException();
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
