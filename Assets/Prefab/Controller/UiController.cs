using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI[] texts;
    public Skill[] skills;
    public GameWatcher watcher;

    public void SetSkillButtons(Skill[] skills)
    {
        this.skills = skills;
        for (int i = 0; i < skills.Length; i++)
        {
            Skill skill = skills[i];
            texts[i].text = skill.name;
        }
    }

    public void OnButtonClick(int n)
    {
        watcher.SetSkill(skills[n]);
    }
}
