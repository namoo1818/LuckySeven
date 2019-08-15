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

    private Animator animator;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetFloat("Dir", -1);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetFloat("Dir", 1);
            animator.SetBool("isWalking", true);
        }

        if (Input.GetAxisRaw("Vertical") == 1 && rigid.velocity.y == 0)
        {
            isJumping = true;
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
    }
}