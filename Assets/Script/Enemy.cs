using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if (hp <= 0) Dead();
        }
    }

    public virtual void Init()
    {
        HP = 1;
    }

    private void Start()
    {
        Init();
    }
    protected virtual void Dead()
    {
        Destroy(gameObject);
    }
}
