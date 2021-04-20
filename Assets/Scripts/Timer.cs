using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : Singleton<Timer>
{

    public TMP_Text timeText;

    public float timeValue = 15f;

    void Start()
    {
        timeText.SetText("" + timeValue);

        timeValue += HackingSkill.skill * HackingSkill.skill;

    }

    void Update()
    {
        if (Manager.canvasSwitched)
            timeValue -= Time.deltaTime;

        timeText.SetText("" + timeValue);

        if (timeValue <= 0)
            SceneManager.LoadScene("LostLevel");
    }
}
