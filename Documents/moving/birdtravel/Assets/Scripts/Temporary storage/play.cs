using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class play : MonoBehaviour {
	public Transform pTransform1;
	public Transform pTransform2;
	public static int life=1;
	public float speed = 5.0f;





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dir2 = Input.GetAxis ("jump");
			transform.Translate (Vector3.up * dir2 * speed * Time.deltaTime);
		move ();
		if(transform.position.y == pTransform1.localPosition.y+1)//조건에 맞는지 여부를 검사합니다. 여기서는 두오브젝트의 위치가 같은지 검사합니다. 
		{ 
			transform.parent = pTransform1; //오브젝트의 페어런트를 pTransform으로 지정하여 줍니다. 
		} 
		if(transform.position.y == pTransform2.localPosition.y+1)//조건에 맞는지 여부를 검사합니다. 여기서는 두오브젝트의 위치가 같은지 검사합니다. 
		{ 
			transform.parent = pTransform2; //오브젝트의 페어런트를 pTransform으로 지정하여 줍니다. 
		} 

	}

	void move()
	{

		Vector3 moveVelocity=Vector3.zero;
		if (Input.GetAxisRaw ("Horizontal")<0) {
			moveVelocity = Vector3.left;
			transform.localScale = new Vector3 (-1, 1, 1);
		} else if (Input.GetAxis ("Horizontal")>0) {
			moveVelocity = Vector3.right;
			transform.localScale = new Vector3 (1, 1, 1);
		}
		transform.position += moveVelocity * speed * Time.deltaTime;
	}

}
