using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    GameObject player;

    public override void Init()
    {
        HP = 3;
        player = GameObject.FindGameObjectWithTag("Player");

    }

   
    protected override void Dead()
    {
        Debug.Log("적이 죽었습니다.");
        base.Dead();
    }

}