using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int teamNumber;
    //GameController nge-watch kelas GameController, jadi harus punya GameController dong
    public GameController gameController;
    public UiController uiController;
    //Skill yang sedang digunakan di turn ini
    public Skill skill;
    //Target character(s) serangan dari skill yang sedang digunakan 
    public Character.Base target;
    //Daftar target yang bisa diserang, buat sekarang tandanya masih warna putih
    public Character.Base[] selectableTarget;
    
    private bool isRun;

    private EnergyManager energyManager;
    private Coroutine coroutine;



    private void Start()
    {
        gameController = GameController.instance;
        uiController = gameController.uiController;
        gameController.gameState.AddListener(PlayerTurn);
        energyManager = GetComponent<EnergyManager>();
        
    }

    void PlayerTurn(int nTeam, Character.Base chara)
    {
        if (nTeam == teamNumber)
        {
            
            chara.YourTurn();
            uiController.SetSkillButtons(chara.skill.skills, energyManager.IsAvailable());
        }
        else if (nTeam == -teamNumber)
        {
            chara.NextTurn();
            NextTurn();
        }
    }

/*    void Update()
    {

            // show UI or some shit  
            if (skill != null)
            {
                //SELECTING TARGET USING RAYCAST
                SetTarget();
                // color chance
                gameController.battleState = GameController.BattleState.LOADING;
                if (target != null)
                {
                    gameController.ActivateSkill(skill, target);
                }
            }
    }*/

    void RefreshMarker()
    {
        //Refresh Selected Target Color
        foreach (Character.Base chr in gameController.teams2)
        {
            chr.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        foreach (Character.Base chr in gameController.teams1)
        {
            chr.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
    }

    void SetMarker()
    {
        if (skill.targetTeam == SkillEnum.Target.Ally)
        {
            selectableTarget = skill.GetTargetSelection(gameController.teams1);
        }
        else if (skill.targetTeam == SkillEnum.Target.Enemy)
        {
            selectableTarget = skill.GetTargetSelection(gameController.teams2);
        }
        else
        {
            selectableTarget = new Character.Base[1];
            selectableTarget[0] = gameController.charaTurn;
        }

        foreach (Character.Base chr in selectableTarget)
        {
            chr.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
    }

    IEnumerator SelectTarget()
    {
        Character.Base chara = SetTarget();
        int count = 0;        
        yield return new WaitUntil(() => target);
        gameController.ActivateSkill(skill, target);
    }

    private void Update()
    {
        if (skill)
        {
            SetTarget();
        }
    }

    public Character.Base SetTarget()
    {

        //Cek jika mouse klik kiri melakukan input, supaya raycast tidak dijalankan tiap thickkk
        if (Input.GetMouseButtonDown(0))
        {
            print("click");
            //Get Mouse Position dari layar, output => (x,y)
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Masukin posisi mouse ke dalam raycast
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            //Cek Tag dari skill yang digunakan, afakah nyerang musuh saja, atau tim
            //Input => ("Ally","Enemy","Self")
            //string tag = skill.target.ToString();

            //Misal posisi mouse yang diklik terdapat collider dan Tag dari object yang terkena raycast
            //Dan Tag nya bernilai benar
            if (hit.collider != null && selectableTarget.Contains(hit.collider.gameObject.GetComponent<Character.Base>()))
            {
                print("hit");
                //Masukin ke dalam character target
                target = hit.collider.gameObject.GetComponent<Character.Base>();


                //Ganti Warna Musuh Ke semula
                foreach (Character.Base chr in selectableTarget)
                {
                    chr.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                return target;
            }
        }
        return null;

    }

    public void SetSkill(Skill skill)
    {
        if (coroutine != null) { StopCoroutine(coroutine);  }
        this.skill = skill;
        RefreshMarker();
        SetMarker();
        coroutine = StartCoroutine(SelectTarget());
    }

    public void NextTurn()
    {
        skill = null;
        target = null;
        energyManager.burstEnergy += 1;
    }
}
