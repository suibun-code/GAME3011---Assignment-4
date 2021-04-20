using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHackingSkill : MonoBehaviour
{
    public void SetSkill(int skill)
    {
        HackingSkill.skill = skill;

        SceneManager.LoadScene("Level 1");
        HackingSkill.currentLevel = 1;
    }
}
