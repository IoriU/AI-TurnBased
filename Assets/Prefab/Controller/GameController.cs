using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Linq;
using System;
using static UnityEngine.EventSystems.EventTrigger;
using JetBrains.Annotations;
using Character;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    //Battle State untuk GameController
    public enum BattleState
    {
        LOADING,
        TEAM1,
        TEAM2,
        LOOP
    }

    public UnityEvent<int, Character.Base> gameState;  

    //For Singleton
    public static GameController instance;

    //Buat nentuin yang lagi jalan bot atau player 
    public bool isCpu1;

    //Var for storing list of character in Team 1
    public GameObject team1Root;
    public Character.Base[] teams1;
    //Var for storing list of character in Team 2
    public GameObject team2Root;
    public Character.Base[] teams2;
    //Char in Team1 and Team2 digabung
    public Character.Base[] allChara;
    //Current Battle State from ENUM
    public BattleState battleState;
    public Character.Base charaTurn;

    //For UI Purpose
    public UiController uiController;
    public PlayerController teamController;

    public Skill dummySkill;
    private bool flag;
    private int teamN;
    private void Awake()
    {
        //Creating Singleton For Gamecontroller//

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

    void Start()
    {
        //Masukin masing masing char ke dalam tim dari child
        teams1 = team1Root.GetComponentsInChildren<Character.Base>();
        int count = 0;
        foreach (Character.Base chara in teams1)
        {
            chara.pos = count;
            count++;
        }
        
        teams2 = team2Root.GetComponentsInChildren<Character.Base>();
        count = 0;
        foreach (Character.Base chara in teams2)
        {
            chara.pos = count;
            count++;
        }
        allChara = teams1.Concat(teams2).ToArray();
        uiController = GetComponent<UiController>();
        battleState = BattleState.LOOP;
    }

    

    void Update()
    {
        //MAIN GAME LOOP HERE
        if (battleState == BattleState.LOOP)
        {
            //Update Speed Bar di semua karakter
            UpdateSpeedBar(Time.deltaTime);
            
            //Cek karakter di tim mana yang punya speed paling besar
            TeamTurnCheck();

            //Handling Status Effect On Turn
            /*if (charTurn != null && charTurn.seManager.effects.Count > 0)
            {
                charTurn.seManager.HandleEffectOnTurn();
            }*/

        }
    }

    public void SimpleAiAttack()
    {
        ActivateSkill(dummySkill, teams1[0]);
        print("ai attack"); 
    }

    public void UpdateSpeedBar(float interval)
    {
        //Cek semua karakter
        foreach (Character.Base chr in allChara)
        {
            //Update karakter tersebut
            chr.speed.UpdateSpeedBar(interval);
        }

        //Setelah update speedBar, maka urutkan semua karakter yang memiliki speed paling tinggi
        allChara = allChara.OrderByDescending(x => x.speed.speedBar).ToArray();
    }

    //Cek karakter di tim mana yang punya speed paling besar
    private void TeamTurnCheck()
    {
        //AMbil di lokasi index paling awal, karena speedbarnya paling tinggi, kalo misal udh >=100
        //Maka ia akan jalan, kalo speedbar allChar[0] sama allChar[1] dst itu sama gatau dah ngurutinnya hehe
        if (allChara[0].speed.speedBar >= 100)
        {

            //Ganti BattleState ke TEAM berapa
            charaTurn = allChara[0];
            teamN = 0;
            if (teams1.Contains(charaTurn))
            {
                battleState = BattleState.TEAM1;
                teamN = 1;

            }
            else if (teams2.Contains(charaTurn))
            {
                battleState = BattleState.TEAM2;
                teamN = 2;
            }

            
            gameState.Invoke(teamN, charaTurn);
            // teamController.SetupTurn(charTurn);
            //uiController.SetSkillButtons(charTurn.skill.skills);
        }
    }

    public (Character.Base[], Character.Base[]) GetCurrentAllyEnemy()
    {
        if (battleState == BattleState.TEAM1)
        {
            return (teams1, teams2);
        }
        else if (battleState == BattleState.TEAM2)
        {
            return (teams2, teams1);
        }
        return (null, null);
    }

    public void ActivateSkill(Skill skill, Character.Base target)
    {
        int userPos = -1, targetPos = -1;
        Character.Base[] ally = null, enemy = null;
        if (battleState == BattleState.TEAM1)
        {
            userPos = Array.IndexOf(teams1, charaTurn);
            targetPos = Array.IndexOf(teams2, target);
            ally = teams1;
            enemy = teams2;
        } else if (battleState == BattleState.TEAM2)
            {
                userPos = Array.IndexOf(teams2, charaTurn);
                targetPos = Array.IndexOf(teams1, target);
                ally = teams2;
                enemy = teams1;
            }
        skill.ActivateSkill(userPos, targetPos, ally, enemy);
        NextTurn();

        
    }

    //Main Next Turn Container
    public void NextTurn()
    {
        //Handling Status Effect
        if (charaTurn.seManager.effects.Count > 0)
        {
            charaTurn.seManager.HandleEffectEndTurn();
        }
        
        uiController.NextTurn();
        gameState.Invoke(-teamN, charaTurn);
        charaTurn = null;
        battleState = BattleState.LOOP;
    }
}
