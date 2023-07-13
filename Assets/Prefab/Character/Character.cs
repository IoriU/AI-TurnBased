using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float def;
    private float curDef;
    public float speed;
    private float curSpeed;
    public float speedBar;
    public BattleState battleState;

    public Skill[] skill;
    
    void Start()
    {
        curHp = hp;
        curDef = def;
        curSpeed = speed;
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
        speedBar += curSpeed * interval;
    }


}
