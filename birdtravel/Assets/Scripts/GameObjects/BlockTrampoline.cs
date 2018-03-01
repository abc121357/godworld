using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrampoline  : MonoBehaviour {
    public BoxCollider2D boxCollider2D = null;
    public static bool shouldShowTrampoline = true;
    public RuntimeAnimatorController redController = null;
    public float jumpPower = 20.0f;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;


    public Sprite redSprite;
    protected Rigidbody2D rigid;
 
    virtual public void UpdateColor()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (shouldShowTrampoline) { 
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
    }

    // Use this for initialization
    void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        redController = animator.runtimeAnimatorController;
        redSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update () {
		if (shouldShowTrampoline)
        {

            animator.runtimeAnimatorController = redController;
            spriteRenderer.sprite = redSprite;
            boxCollider2D.isTrigger = false;
        }
        else
        {
          //  Debug.Log("hidee!!");
            spriteRenderer.sprite = null;
            animator.runtimeAnimatorController = null;
            boxCollider2D.isTrigger = true;
        }
    }
}
