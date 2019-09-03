using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject boxObject;
    float nowTime;
    float time;

    void Start()
    {
        nowTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        if (Time.time - nowTime > 1f && time <= 10f)
        {
            GameObject part;

            part = Instantiate(boxObject, new Vector3(Random.Range(-5f, 13f), 20f, 0f), Quaternion.identity); // 객체 생성    
                                                                                                              //part.GetComponent<BombMove>().setPostion(Random.Range(-3, 3), 5f, 0.07f);//Random.Range(0.05f, 0.1f)

            nowTime = Time.time;
        }


    }
}