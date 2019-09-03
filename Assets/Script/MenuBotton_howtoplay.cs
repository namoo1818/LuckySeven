using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBotton_howtoplay : MonoBehaviour
{
    public GameObject Manual;

    public void ManualSetActive()
    {
        Manual.SetActive(!Manual.activeSelf);
    }
}
