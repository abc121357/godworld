using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrampoline : Trampoline {
    public BoxCollider2D boxCollider2D = null;
    public static bool shouldShowTrampoline = true;
    public RuntimeAnimatorController redController = null;

    public Sprite redSprite;

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
            Debug.Log("hidee!!");
            spriteRenderer.sprite = null;
            animator.runtimeAnimatorController = null;
            boxCollider2D.isTrigger = true;
        }
    }
}
