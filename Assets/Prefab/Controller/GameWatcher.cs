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
    //button njirrr
    public Button[] team1;
    public Button[] team2;

    private void Start()
    {
        gameController = GameController.instance;
        
    }

    void Update()
    {
        if (!gameController.isCpu1 && (gameController.battleState == GameController.BattleState.TEAM1))
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
                    target = null;
                    skill = null;
                }
            }
        }
    }

    public IEnumerator PlayerTurn()
    {
        StartCoroutine(SelectSkill());
        yield return SelectSkill();
        StartCoroutine(SelectTarget());
        yield return SelectTarget();
    }

    public IEnumerator SelectSkill()
    {
        while (skill != null)
        {
            yield return null;
        }
    }

    public void SetSkill(Skill skill)
    {
        this.skill = skill;
        
    }

    public IEnumerator SelectTarget()
    {
        while (target != null)
        {
            yield return null;
        }
    }

    public void SetTarget()
    {
        //Cek jika mouse klik kiri melakukan input, supaya raycast tidak dijalankan tiap thickkk
        if(Input.GetMouseButtonDown(0)) {
            //Get Mouse Position dari layar, output => (x,y)
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Masukin posisi mouse ke dalam raycast
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            //Cek Tag dari skill yang digunakan, afakah nyerang musuh saja, atau tim
            //Input => ("Ally","Enemy","Self")
            string tag = skill.targetTeam.ToString();

            //Misal posisi mouse yang diklik terdapat collider dan Tag dari object yang terkena raycast
            //Dan Tag nya bernilai benar
            if (hit.collider != null && hit.collider.CompareTag(tag))
            {
                //Masukin ke dalam character target
                target = hit.collider.gameObject.GetComponent<Character>();
                //Debugging
                Debug.Log("HIT: " + hit.collider.gameObject.name);
                Debug.Log("TARGET TEAM: " + skill.targetTeam);
            }
        }
        
    }
}
