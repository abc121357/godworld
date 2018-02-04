using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    static public int life = 3;
    public GameObject bird;
    public float movepower = 1.0f;
    public float jumppower = 1.0f;
    public Rigidbody2D rigid;
    public bool isjumping = false;
    public bool canjumping = true;
    public Animator animator;
    private Transform m_currMovingPlatform;
    //    private Vector3 velocity = Vector3.zero;
    public float limitVelocity = 20.0f;
    //  private Vector3 prevPos;

    public static void Die()
    {
        life--;
        GameManager.Reset();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") // 게임태그가 적이면
        {
            other.enabled = false;
            Die();

        }
        animator.SetBool("isjumping", false);
        if (other.gameObject.tag == "ClearPoint")
        {
            other.enabled = false;
            GameManager.ClearStage();

        }
        if (other.gameObject.tag == "MovingSurfaceCollider")
        {
            m_currMovingPlatform = other.gameObject.transform;
            transform.SetParent(m_currMovingPlatform);
        }
        if (other.gameObject.layer == 0 && rigid.velocity.y < 0)
        {
            canjumping = true;

        }
        Debug.Log("Attach : " + other.gameObject.layer);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingSurfaceCollider")
        {

            m_currMovingPlatform = null;
            transform.parent = null;
        }
        if (collision.gameObject.layer == 0 && rigid.velocity.y > 0)
        {
            canjumping = false;

        }

    }

    // Use this for initialization
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -4)
        {
            Die();
            return;
        }
        // Debug.Log(velocity.magnitude);

        if (rigid.velocity.magnitude > limitVelocity && rigid.velocity.magnitude < 100)
        {

            rigid.velocity = Vector3.zero;
            Die();
            return;

        }


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetInteger("position", -1);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetInteger("position", 1);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetInteger("position", 0);
        }

        if (Input.GetButtonDown("Jump") && !animator.GetBool("isjumping") && canjumping)
        {
            isjumping = true;
            animator.SetBool("isjumping", true);
            animator.SetTrigger("dojumping");
        }
    }


    void FixedUpdate()
    {
        move();
        Jump();


        /*        Vector3 diff = (transform.position - prevPos);
                velocity = (transform.position - prevPos) / Time.deltaTime;

                prevPos = transform.position;
          */
    }

    void move()
    {
        Vector3 moveVelocity = Vector3.zero;


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += moveVelocity * movepower * Time.deltaTime;

    }

    void Jump()
    {
        if (!isjumping)
        {
            return;
        }

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumppower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isjumping = false;



    }




}
