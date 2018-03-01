using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    virtual public void UpdateColor()
    {

    }
    public float jumpPower = 10.0f;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    // Use this for initialization

    protected Rigidbody2D rigid;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        
            Rigidbody2D rigid = collision.GetComponent<Rigidbody2D>();

            if (rigid.velocity.y <= 0)
            {
                rigid.velocity = Vector2.zero;
                Vector2 jumpVelocity = new Vector2(0, jumpPower);
                rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
               
                movement movement = collision.GetComponent<movement>();
                if (movement != null)
                {
                    UpdateColor();

                    movement.canjumping = false;
                    movement.animator.SetBool("isjumping", true);
                    movement.animator.SetTrigger("dojumping");
                }
            }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
