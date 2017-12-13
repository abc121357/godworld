using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    static public bool reset = false; // 게임 오브젝트 리셋
    static public float life = 3;
	public GameObject bird;
	public float movepower = 1.0f;
	public float jumppower = 1.0f;
	Rigidbody2D rigid;
	bool isjumping = false;
	Animator animator;

	void OnTriggerEnter2D(Collider2D other)
	{
        if(other.gameObject.tag=="Enemy") // 게임태그가 적이면
        {
            if (SavePointTrigger.Plag == true)
            {
                transform.position = new Vector2(100, 2.63f);
            }

            else
            {
                transform.position = new Vector2(0, 2.63f);
            }
            life -= 1;
            reset = true;


        }
		animator.SetBool ("isjumping", false);
        if (other.gameObject.tag == "ClearPoint")
        {
            other.enabled = false;
            GameManager.ClearStage();
        }
    }

	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody2D> ();
		animator = gameObject.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -4) {
			if (SavePointTrigger.Plag == true) { // abc : 세이브포인트가 on일시
				transform.position = new Vector2 (100, 3); // abc : 플래그지점에서 재ㅇ성
				life -= 1;
				return;
			}
			transform.position = new Vector2 (0, 3);
            life -= 1;
            reset = true;

		}
		if (Input.GetAxisRaw ("Horizontal") < 0) {
			animator.SetInteger ("position", -1);
		} else if (Input.GetAxisRaw ("Horizontal") > 0) {
			animator.SetInteger ("position", 1);
		}
		else if(Input.GetAxisRaw("Horizontal") == 0) {
			animator.SetInteger("position",0);
		}

		if (Input.GetButtonDown ("Jump")&&!animator.GetBool("isjumping")) {
			isjumping = true;
			animator.SetBool ("isjumping",true);
			animator.SetTrigger("dojumping");
		}
	}

  
    void FixedUpdate()
	{
		move ();
		Jump ();
	}

	void move()
	{
		Vector3 moveVelocity = Vector3.zero;

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			moveVelocity = Vector3.left;
			transform.localScale = new Vector3 (-1, 1, 1);
		} else if (Input.GetAxisRaw ("Horizontal") > 0) {
			moveVelocity = Vector3.right;
			transform.localScale = new Vector3 (1,1,1);
		}
		transform.position += moveVelocity * movepower * Time.deltaTime;

	}

	void Jump()
	{
		if (!isjumping) {
			return;
		}

		rigid.velocity = Vector2.zero;

		Vector2 jumpVelocity = new Vector2 (0, jumppower);
		rigid.AddForce (jumpVelocity, ForceMode2D.Impulse);

		isjumping = false;



	}




}
