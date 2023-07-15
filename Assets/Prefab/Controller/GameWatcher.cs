using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameWatcher : MonoBehaviour
{

    public GameController gameController;
    public Skill skill;
    public Character target;
    public Button[] team1;
    public Button[] team2;

    private void Start()
    {
        gameController = GameController.instance;
        for (int i = 0; i < GameController.instance.teams1.Length; i++)
        {
            team1[i].onClick.AddListener(() => SetTarget("Ally", i));
        }
        for (int i = 0; i < GameController.instance.teams2.Length; i++)
        {
            team1[i].onClick.AddListener(() => SetTarget("Ally", i));
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!gameController.isCpu1 && (gameController.battleState == GameController.BattleState.Team1))
        {
            // show UI or some shit  
            if (skill != null)
            {
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

    public void SetTarget(string type, int pos)
    {
        // You can perform any additional actions here based on the message and value received.
    }
}
