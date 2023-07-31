using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] buttons;
    public TextMeshProUGUI[] texts;
    public Skill[] skills;
    public PlayerController player;

    public void SetSkillButtons(Skill[] skills, bool isBurstReady)
    {
        this.skills = skills;
        for (int i = 0; i < 5; i++)
        {
            TextMeshProUGUI text = buttons[i].GetComponent<TextMeshProUGUI>();
            Skill skill = skills[i];
            texts[i].text = skill.name;   
            if (!skill.IsReady())
            {
                buttons[i].interactable = false;
            } else
            {
                buttons[i].interactable = true;
            }
        }
        if (isBurstReady)
        {
            buttons[4].interactable = true;
        } else
        {
            buttons[4].interactable = false;
        }
    }

    public void OnButtonClick(int n)
    {
        player.SetSkill(skills[n]);
        
    }

    public void NextTurn()
    {
        skills = null;
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = "";
        }
    }
}
