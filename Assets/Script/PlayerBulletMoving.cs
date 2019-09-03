using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMoving : MonoBehaviour
{
    public float bulletSpeed = 15f;  // 탄환의 속도
    private float destroyTime = 1.9f;  // 탄환 유지 시간
    private float damage = 1f;  // 탄환의 위력
    //private float direction; // 플레이어의 방향(탄환 발사 방향){필요없어짐)

    private Vector2 bulletVelocity = new Vector2(0, 0);

    private int selected_character; // 선택된 캐릭터를 나타내는 변수
    private int selected_weapon; // 선택된 무기를 나타내는 변수

    private Rigidbody2D rigid;

    private character ch; // 캐릭터, 무기 선택 변수 접근위한 선언

    //애니메이션에 있는 방향 변수 접근위한 선언
    private GameObject player;
    //private Animator animator;

    void Start()
    {
        ch = GameObject.Find("Character_menu").GetComponent<character>();
        selected_weapon = ch.weapons;

        switch (selected_weapon)
        {
            case 0:
                damage = 1f;
                destroyTime = 1.9f;
                break;
            case 1:
                damage = 2f;
                destroyTime = 0.85f;
                break;
            case 2:
                damage = 3f;
                destroyTime = 1.9f;
                break;
        }
        //player = GameObject.Find("Player");
        //animator = player.GetComponent<Animator>();

        rigid = GetComponent<Rigidbody2D>();

        //direction = animator.GetFloat("Dir");

        bulletVelocity = new Vector2(bulletSpeed, 0);

        rigid.AddForce(bulletVelocity, ForceMode2D.Impulse);

        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
