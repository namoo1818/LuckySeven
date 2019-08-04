using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBotton_start : MonoBehaviour
{
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("0_start");
    }

    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("1_character");
    }

    public void ChangeThirdScene()
    {
        SceneManager.LoadScene("2_story");
    }

    public void ChangeFourthScene()
    {
        SceneManager.LoadScene("3_stage");
    }
}
