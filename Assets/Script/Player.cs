using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movePower = 10f;
    public float jumpPower = 10f;

    public int maxHealth=3;
    public int curHealth;

    private Rigidbody2D rigid;

    private Vector3 moveVecor;
    private bool isJumping = false;
    private bool isDie = false;

    private Animator animator;

    private GameObject bullet;
    public float coolDown;
    private const float MAXCOONDOWN = 0.2f;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        curHealth = maxHealth;
        bullet = Resources.Load<GameObject>("pBullet");
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

        if (coolDown <= 0 && Input.GetKey(KeyCode.LeftControl))
        {
            Fire();
        }

        if (coolDown > 0) coolDown -= Time.deltaTime;


        if (curHealth <= 0)
        {
            if (!isDie)
                Die();
            return;
        }
    }

    void FixedUpdate()
    {
        Move();
        Jump();

        if (curHealth == 0)
            return;
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

        transform.position += moveVelocity * movePower * Time.deltaTime;
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

    void Die()
    {
        isDie = true;

        rigid.velocity = Vector2.zero;

        animator.Play("Die");

        BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>();
        colls[0].enabled = false;
        colls[1].enabled = false;

        Vector2 dieVelocity = new Vector2(0, 10f);
        rigid.AddForce(dieVelocity, ForceMode2D.Impulse);
        Debug.LogError("게임오버");
        GameObject.Find("Canvas").transform.Find("GameOverPanel").gameObject.SetActive(true);
        Time.timeScale = 0f;

    }

    void Fire()
    {
        if (bullet == null) return;
        GameObject newObject = Instantiate(bullet);
        pBullet newBullet = newObject.GetComponent<pBullet>();
        newBullet.Fire(transform.position, Vector3.left, 15f);
        coolDown = MAXCOONDOWN;

    }

}