using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;  //발사할 탄환 
    public float waitTerm = 1f;  //발사 주기
    private float shootTimer = 0; //시간을 잴 타이머
    private bool canShoot = true; // 발사가능 여부

    private int selected_weapon; // 선택된 무기를 나타내는 변수

    private character ch; // 캐릭터, 무기 선택 변수 접근위한 선언

    private Animator animator; // 슈팅 애니메이션 조건인 isShooting을 변경하기 위해

    void Start()
    {
        // character 씬의 don't destroy 오브젝트인 Character_menu의 character.cs 스크립트에 접근
        ch = GameObject.Find("Character_menu").GetComponent<character>(); 
        selected_weapon = ch.weapons;

        animator = GetComponent<Animator>();

        switch (selected_weapon)
        {
            case 0:
                waitTerm = 0.2f;
                bullet = Resources.Load("Prefabs/smg_bullet") as GameObject; // smg 탄환 생성
                break;
            case 1:
                waitTerm = 0.3f;
                bullet = Resources.Load("Prefabs/shotgun_bullet") as GameObject; // shotgun 탄환생성
                break;
            case 2:
                waitTerm = 0.5f;
                bullet = Resources.Load("Prefabs/roket_bullet") as GameObject; // roket launcher 탄환생성
                break;
        }
    }

    IEnumerator ShootBullet()
    {
        while (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);

            while (shootTimer < waitTerm)
            {
                shootTimer += Time.deltaTime;
                yield return new WaitForSeconds(0.01f);
            }
            shootTimer = 0;
        }
        canShoot = true;
        animator.SetBool("isShooting", false);
    }

    void Update()
    {
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("isShooting", true);
                canShoot = false;
                StartCoroutine(ShootBullet());
            }
        }
    }
}
