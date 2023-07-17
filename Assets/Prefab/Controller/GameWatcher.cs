using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameWatcher : MonoBehaviour
{
    //GameWatcher nge-watch kelas GameController, jadi harus punya GameController dong
    public GameController gameController;
    //Skill yang sedang digunakan di turn ini
    public Skill skill;
    //Target character(s) serangan dari skill yang sedang digunakan 
    public Character target;
    //Daftar target yang bisa diserang, buat sekarang tandanya masih warna putih
    public Character[] selectableTarget;
    //button njirrr
    public Button[] team1;
    public Button[] team2;
    private bool isRun;

    private void Start()
    {
        gameController = GameController.instance;
        
    }

    void Update()
    {
        if (!gameController.isCpu1 && (gameController.battleState == GameController.BattleState.TEAM1) && !isRun)
        {
            
            // show UI or some shit  
            if (skill != null)
            {
                //SELECTING TARGET USING RAYCAST
                SetTarget();

                // color chance
                if (target != null)
                {
                    // aktifin skill
                    isRun = true;
                    gameController.ActivateSkill(skill, target);
                    

                }
            }
        } 

    }


    public void SetSkill(Skill skill)
    {
        this.skill = skill;
        
    }

    //Set Selected Target to attack
    public void SetTarget()
    {
        //Refresh Selected Target COlor
        foreach (Character chr in gameController.teams2)
        {
            chr.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        foreach (Character chr in gameController.teams1)
        {
            chr.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }

        //Target yang bisa diserang oleh skillnya
        if (skill.targetTeam == SkillEnum.Target.Ally)
        {
            selectableTarget = skill.GetTargetSelection(gameController.teams1);
        } else if(skill.targetTeam == SkillEnum.Target.Enemy)
        {
            selectableTarget = skill.GetTargetSelection(gameController.teams2);
        } else
        {
            selectableTarget = new Character[1];
            selectableTarget[0] = gameController.charTurn;
        }

        foreach (Character chr in selectableTarget)
        {
            chr.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
        
        //Cek jika mouse klik kiri melakukan input, supaya raycast tidak dijalankan tiap thickkk
        if (Input.GetMouseButtonDown(0))
        {
            //Get Mouse Position dari layar, output => (x,y)
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Masukin posisi mouse ke dalam raycast
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            //Cek Tag dari skill yang digunakan, afakah nyerang musuh saja, atau tim
            //Input => ("Ally","Enemy","Self")
            //string tag = skill.target.ToString();

            //Misal posisi mouse yang diklik terdapat collider dan Tag dari object yang terkena raycast
            //Dan Tag nya bernilai benar
            if (hit.collider != null && selectableTarget.Contains(hit.collider.gameObject.GetComponent<Character>()))
            {
                //Masukin ke dalam character target
                target = hit.collider.gameObject.GetComponent<Character>();

                
                //Ganti Warna Musuh Ke semula
                foreach (Character chr in selectableTarget)
                {
                    chr.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
            }
        }
        
    }

    public void NextTurn()
    {
        skill = null;
        target = null;
        isRun = false;
    }
}
