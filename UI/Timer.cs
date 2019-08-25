﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float LimitTime;
    public Text text_Timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LimitTime -= Time.deltaTime;
        text_Timer.text = "TIME: " + Mathf.Round(LimitTime);
        if(LimitTime<=0)
        {
            Debug.LogError("게임오버");
            GameObject.Find("Canvas").transform.Find("GameOverPanel").gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}