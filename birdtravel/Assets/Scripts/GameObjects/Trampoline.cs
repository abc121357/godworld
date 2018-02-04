using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {
    public float jumpPower = 20.0f;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D collision)
    {
        {
            Rigidbody2D rigid = collision.GetComponent<Rigidbody2D>();
            
            if ( rigid.velocity.y <= 0) {
                rigid.velocity = Vector2.zero;

                Vector2 jumpVelocity = new Vector2(0, jumpPower);
                rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

                movement movement = collision.GetComponent<movement>();
                if (movement != null)
                {


                    movement.canjumping = true;
                    movement.animator.SetBool("isjumping", true);
                    movement.animator.SetTrigger("dojumping");
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
