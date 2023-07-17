using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Linq;
using System;
using static UnityEngine.EventSystems.EventTrigger;
using JetBrains.Annotations;

public class GameController : MonoBehaviour
{
    //Battle State untuk GameController
    public enum BattleState
    {
        IDLE,
        TEAM1,
        TEAM2,
        LOOP
    }
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
    public Character.Base[] allChar;
    //Current Battle State from ENUM
    public BattleState battleState;
    public Character.Base charTurn;

    //For UI Purpose
    public UiController uiController;
    public GameWatcher gameWatcher;
    void Start()
    {
        //Masukin masing masing char ke dalam tim dari child
        teams1 = team1Root.GetComponentsInChildren<Character.Base>();
        teams2 = team2Root.GetComponentsInChildren<Character.Base>();
        allChar = teams1.Concat(teams2).ToArray();
        
        //Abis setup Tim, langsung masuk ke dalem state LOOP
        battleState = BattleState.LOOP;
        uiController = GetComponent<UiController>();
        gameWatcher = GetComponent<GameWatcher>();

    }

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

    void Update()
    {
        //MAIN GAME LOOP HERE
        if (battleState == BattleState.LOOP)
        {
            //Update Speed Bar di semua karakter
            UpdateSpeedBar(Time.deltaTime);
            
            //Cek karakter di tim mana yang punya speed paling besar
            TeamTurnCheck();
        }
    }

    public void UpdateSpeedBar(float interval)
    {
        //Cek semua karakter
        foreach (Character.Base chr in allChar)
        {
            //Update karakter tersebut
            chr.speed.UpdateSpeedBar(interval);
        }

        //Setelah update speedBar, maka urutkan semua karakter yang memiliki speed paling tinggi
        allChar = allChar.OrderByDescending(x => x.speed.speedBar).ToArray();
    }

    //Cek karakter di tim mana yang punya speed paling besar
    private void TeamTurnCheck()
    {
        //AMbil di lokasi index paling awal, karena speedbarnya paling tinggi, kalo misal udh >=100
        //Maka ia akan jalan, kalo speedbar allChar[0] sama allChar[1] dst itu sama gatau dah ngurutinnya hehe
        if (allChar[0].speed.speedBar >= 100)
        {

            //Ganti BattleState ke TEAM berapa
            charTurn = allChar[0];

            if (teams1.Contains(charTurn))
            {
                battleState = BattleState.TEAM1;
            }
            else if (teams2.Contains(charTurn))
            {
                battleState = BattleState.TEAM2;
            }

            charTurn.speed.YourTurn();
            uiController.SetSkillButtons(charTurn.skill.skills);
        }
    }

    public void ActivateSkill(Skill skill, Character.Base target)
    {
        int userPos = -1, targetPos = -1;
        Character.Base[] ally = null, enemy = null;
        if (battleState == BattleState.TEAM1)
        {
            userPos = Array.IndexOf(teams1, charTurn);
            targetPos = Array.IndexOf(teams2, target);
            ally = teams1;
            enemy = teams2;
        } else if (battleState == BattleState.TEAM2)
            {
                userPos = Array.IndexOf(teams2, charTurn);
                targetPos = Array.IndexOf(teams1, target);
                ally = teams2;
                enemy = teams1;
            }
        skill.ActivateSkill(userPos, targetPos, ally, enemy);
        NextTurn();
    }

    public void NextTurn()
    {

        charTurn.speed.NextTurn();
        charTurn = null;
        uiController.NextTurn();
        gameWatcher.NextTurn();
        battleState = BattleState.LOOP;
    }
}
