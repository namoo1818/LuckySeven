using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor_choice : MonoBehaviour
{
    int charactors;
    int weapons;
    public GameObject[] sHero = new GameObject[2];
    public GameObject[] SWeapon = new GameObject[3];
    GameObject respawn = null;

    public GameObject effect;

    public void ManualSetActive()
    {

        if (Input.GetMouseButtonDown(0))
        {
            effect.SetActive(!effect.activeSelf);
        }

    }


    // Use this for initialization
    public void Choice()
    {

    }

}