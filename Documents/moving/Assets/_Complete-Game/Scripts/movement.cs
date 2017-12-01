using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	public GameObject bird;
	public float movepower = 1.0f;
	public float jumppower = 1.0f;
	Rigidbody2D rigid;
	bool isjumping = false;
	Animator animator;

	void OnTriggerEnter2D(Collider2D other)
	{
		animator.SetBool ("isjumping", false);
	}

	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody2D> ();
		animator = gameObject.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -2) {
			transform.position = new Vector2 (0, 3);

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
