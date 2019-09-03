using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_menu : MonoBehaviour
{
    character ch;

    // Start is called before the first frame update
    void Start()
    {
        ch = character.charData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectMan()
    {
        ch.selectMan();
    }
    public void selectWoman()
    {
        ch.selectWoman();
    }

    public void selectSmg()
    {
        ch.selectSmg();
    }
    public void selectShotGun()
    {
        ch.selectShotGun();
    }
    public void selectRocket()
    {
        ch.selectRocket();
    }
}
