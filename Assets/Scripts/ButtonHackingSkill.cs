using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHackingSkill : MonoBehaviour
{
    public TMP_Text hackText;

    public void SetSkill(int skill)
    {
        HackingSkill.skill = skill;

        SceneManager.LoadScene("Level 1");
        HackingSkill.currentLevel = 1;
    }

    public void Start()
    {
        if (hackText != null)
            hackText.SetText("Hacking skill: " + HackingSkill.skill);
    }

    public void Update()
    {
        if (hackText != null)
            hackText.SetText("Hacking skill: " + HackingSkill.skill);
    }
}
