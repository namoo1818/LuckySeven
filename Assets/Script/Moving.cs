using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float movePower = 10f;
    public float jumpPower = 10f;

    private Rigidbody2D rigid;

    private Vector3 moveVecor;
    private bool isJumping = false;

    private int selected_character; // 선택된 캐릭터를 나타내는 변수

    private character ch; // 캐릭터 선택 변수 접근위한 선언

    private Animator animator;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        ch = GameObject.Find("Character_menu").GetComponent<character>();
        selected_character = ch.characters;

        animator.SetFloat("gender", selected_character);
    }

    void Update()
    { 
        // 애니메이션
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //animator.SetFloat("Dir", -1);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //animator.SetFloat("Dir", 1);
            animator.SetBool("isWalking", true);
        }

        //점프 가능 확인
        if (Input.GetAxisRaw("Vertical") == 1 && rigid.velocity.y == 0)
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
        }
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }
        
        transform.position += moveVelocity * movePower * Time.fixedDeltaTime;
    }

    void Jump()
    {
        if (!isJumping)
            return;

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
        animator.SetBool("isJumping", isJumping);
    }
}