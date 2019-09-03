using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMove : MonoBehaviour
{
    float xpos; // 소수점까지 지정 가능한 변수 
    float ypos;
    float zpos;
    float speed=0.1f;
    float nowTime;
    bool collid = false;

    // Update is called once per frame
    void Start()
    {
        nowTime = Time.time;
    }

    void Update()
    {
        
        xpos = transform.position.x;
        ypos = transform.position.y;
        zpos = transform.position.z;

        if (Time.time - nowTime > 1f)
        {
            if ((int)Random.Range(0, 2f) == 0)
                speed = speed * -1;
            nowTime = Time.time;
        }

        if(collid == true)
            xpos = xpos - speed;
        transform.position = new Vector3(xpos, ypos, zpos);
        
        if (ypos < -3f)
        {
            Destroy(gameObject);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collid = true;    
    }

    public void setPostion(float x, float y, float s)
    {
        xpos = x;
        ypos = y;
        speed = s;
    }
}
