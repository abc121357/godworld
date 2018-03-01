using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowTrampoline : Trampoline {
    enum Color { Red, Orange, Yellow, Green, Blue, Indigo, Violet };
    public int rainbowState = (int)Color.Red;

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
    public static int[] idArray = new int[] { 0,0,0,0,0,0,0};
    
    bool UpdateIdArray(int rainbowState)
    {
        if (rainbowState < (int)Color.Red || rainbowState > (int)Color.Violet) 
        {
            return false;
        }
        if (id < 0 || id >= 7)
        {
            return false;
        }
        idArray[id] = rainbowState;
        return true;
    }

    bool CheckColorPuzzle()
    {
        for (int i = 0; i < 7; i++)
        {
            if (idArray[i] != i)
            {
                return false;
            }
        }
        return true;
    }

    override public void UpdateColor()
    {
        if (rainbowState == (int)Color.Violet)
        {
            rainbowState = (int)Color.Red;
        }
        else
        {
            rainbowState++;
        }

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
        if (UpdateIdArray(rainbowState))
        {
            if (CheckColorPuzzle())
            {
                //Debug.Log("hide!");
                BlockTrampoline.shouldShowTrampoline = false;
            }else
            {
                BlockTrampoline.shouldShowTrampoline = true;

            }
        }
    }
   
}
