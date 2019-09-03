using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public int characters = -1; // -1: 미선택, 0: 남자, 1: 여자
    public int weapons = -1;    // -1: 미선택, 0: smg,  1: 샷건, 2: 로켓
    private int health = -1;    //  -1: 미선택, 0:         
    public static character charData;

    
    void Awake()
    {
        charData = this;
        DontDestroyOnLoad(gameObject);
    }

    public void selectMan()
    {
        characters = 0;
    }
    public void selectWoman()
    {
        characters = 1;
    }

    public void selectSmg()
    {
        weapons = 0;
    }
    public void selectShotGun()
    {
        weapons = 1;
    }
    public void selectRocket()
    {
        weapons = 2;
    }

}
