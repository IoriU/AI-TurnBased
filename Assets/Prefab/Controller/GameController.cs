using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Linq;
using System;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public enum BattleState
    {
        Idle,
        Team1,
        Team2,
        Loop
    }

    public static GameController instance;
    public bool isCpu1;
    public GameObject team1Root;
    public Character[] teams1;

    public GameObject team2Root;
    public Character[] teams2;

    public Character[] allChar;
    public BattleState battleState;

    public UiController uiController;
    void Start()
    {
        teams1 = team1Root.GetComponentsInChildren<Character>();
        teams2 = team2Root.GetComponentsInChildren<Character>();
        allChar = teams1.Concat(teams2).ToArray();
        battleState = BattleState.Loop;
    }

    private void Awake()
    {
        // Check if an instance already exists
        if (instance != null && instance != this)
        {
            // If an instance exists, destroy this GameObject
            Destroy(gameObject);
        }
        else
        {
            // Set the instance and mark it as persistent across scenes
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (battleState == BattleState.Loop)
        {
            UpdateSpeedBar(Time.deltaTime);
        }
    }

    public void UpdateSpeedBar(float interval)
    {
        foreach (Character chr in allChar)
        {
            chr.UpdateSpeedBar(interval);
        }
        allChar = allChar.OrderByDescending(x => x.speedBar).ToArray();
        TeamTurnCheck();
    }

    private void TeamTurnCheck()
    {
        if (allChar[0].speedBar >= 100)
        {
            Character charTurn = allChar[0];
            if (teams1.Contains<Character>(charTurn))
            {
                battleState = BattleState.Team1;
            }
            else if (teams2.Contains<Character>(charTurn))
            {
                battleState = BattleState.Team2;
            }
            charTurn.YourTurn();
            uiController.SetSkillButtons(charTurn.skill);
        }
    }

    public void ActivateSkill(Skill skill, Character user, Character target)
    {
        foreach (Effect effect in skill.effects)
        {
            /*if (effect.type == "Ally")*/
            ;
        }
    }
}
