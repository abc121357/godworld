using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatform : MonoBehaviour {
    private Rigidbody2D rigid;
    public float jumpPower = 20.0f;
    public int jumpDelaySeconds = 2;
    private bool collided = false;
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        collided = true;

        yield return new WaitForSeconds(jumpDelaySeconds);
        if (collided) {
            rigid = collision.GetComponent<Rigidbody2D>();
            rigid.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

            movement movement = collision.GetComponent<movement>();
            if (movement != null)
            {


                //movement.isjumping = true;
                movement.animator.SetBool("isjumping", true);
                movement.animator.SetTrigger("dojumping");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
