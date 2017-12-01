using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour {
	int a = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.localPosition.y > 3.0f) {
			a = -1;
		}
		else if (transform.localPosition.y < -1.0f) {
			a = 1;
		}


		transform.Translate(Vector2.up*5.0f*Time.deltaTime*a);


	}
}
