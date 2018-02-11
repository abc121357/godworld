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
    public RuntimeAnimatorController redController = null;
    public RuntimeAnimatorController orangeController = null;
    public RuntimeAnimatorController yellowController = null;
    public RuntimeAnimatorController greenController = null;
    public RuntimeAnimatorController blueController = null;
    public RuntimeAnimatorController indigoController = null;
    public RuntimeAnimatorController violetController = null;
    
    public int id = -1;
    public int level = -1;
    public static int[][] idArray = new int[3][];

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
    /*
    bool CheckColorPuzzle(int level)
    {
        for (int i = 0; i < 7; i++)
        {
            if (idArray[level][] != i)
            {
                return false;
            }
        }
        return true;
    }*/

    void UpdateColor()
    {
        if (rainbowState ==  (int)Color.Violet)
        {
            rainbowState = (int)Color.Red;
        }else
        {
            rainbowState++;
        }
      
        /*
if (id >= 0 && id < 7)
{
idArray[id] = rainbowState;
if (CheckColorPuzzle())
{
Debug.Log("hello");
}
}*/
        switch (rainbowState)
        {
            case (int)Color.Red:
                //spriteRenderer.sprite = redSprite;
                animator.runtimeAnimatorController = redController;
                break;
            case (int)Color.Orange:
                //spriteRenderer.sprite = orangeSprite;
                animator.runtimeAnimatorController = orangeController;
                break;
            case (int)Color.Yellow:
                //spriteRenderer.sprite = yellowSprite;
                animator.runtimeAnimatorController = yellowController;
                break;
            case (int)Color.Green:
                //spriteRenderer.sprite = greenSprite;
                animator.runtimeAnimatorController = greenController;
                break;
            case (int)Color.Blue:
                //spriteRenderer.sprite = blueSprite;
                animator.runtimeAnimatorController = blueController;
                break;
            case (int)Color.Indigo:
                //spriteRenderer.sprite = indigoSprite;
                animator.runtimeAnimatorController = indigoController;
                break;
            case (int)Color.Violet:
                //spriteRenderer.sprite = violetSprite;
                animator.runtimeAnimatorController = violetController;
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
