using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBotton_start : MonoBehaviour
{
    private character ch;

    void Start()
    {
        ch = GameObject.Find("Character_menu").GetComponent<character>();
    }
    
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
        if (ch.characters != -1 && ch.weapons != -1)
            SceneManager.LoadScene("2_story");
    }

    public void ChangeFourthScene()
    {
        SceneManager.LoadScene("3_stage");
    }
}
