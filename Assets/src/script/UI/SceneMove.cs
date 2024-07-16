using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    public void loadMenu()
    {
        Center.instance.playerFear = 0;
        Center.instance.playerHP = Center.instance.playerMaxHP;
        Center.instance.playerStamina = Center.instance.playerMaxStamina;
        Center.instance.isCorrectOnQuestion = true;
        Center.instance.staminaTimer = Center.instance.staminaTimerLimit;
        Center.instance.step = Center.StartAnimatingPartition.none;
        Center.instance.questionToken = 0;

        Time.timeScale = 1f;

        LoadingSceneManager.LoadScene("Title");
    }
}
