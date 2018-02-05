using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public Sprite redSprite;
    public Sprite orangeSprite;
    public Sprite yellowSprite;
    public Sprite greenSprite;
    public Sprite blueSprite;
    public Sprite indigoSprite;
    public Sprite violetSprite;

    public float jumpPower = 20.0f;
    enum Color { Red, Orange, Yellow, Green, Blue, Indigo, Violet};
    public int rainbowState = (int) Color.Red;
    public Animator animator;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization

    public Rigidbody2D rigid;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }
    void UpdateColor()
    {
        if (rainbowState ==  (int)Color.Violet)
        {
            rainbowState = (int)Color.Red;
        }else
        {
            rainbowState++;
        }

        spriteRenderer.sprite = orangeSprite;
        switch (rainbowState)
        {
            case (int)Color.Red:
                spriteRenderer.sprite = redSprite;
                break;
            case (int)Color.Orange:
                spriteRenderer.sprite = orangeSprite;
                break;
            case (int)Color.Yellow:
                spriteRenderer.sprite = yellowSprite;
                break;
            case (int)Color.Green:
                spriteRenderer.sprite = greenSprite;
                break;
            case (int)Color.Blue:
                spriteRenderer.sprite = blueSprite;
                break;
            case (int)Color.Indigo:
                spriteRenderer.sprite = indigoSprite;
                break;
            case (int)Color.Violet:
                spriteRenderer.sprite = violetSprite;
                break;
            default:
                break;

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
