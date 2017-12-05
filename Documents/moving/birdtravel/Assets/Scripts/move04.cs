using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move04 : MonoBehaviour {
	int a = 1;
    public float speed = 5; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.localPosition.y > 4.85f) {
			a = -1;
		}
		else if (transform.localPosition.y < -0.85f) {
			a = 1;
		}


		transform.Translate(Vector2.up*speed*Time.deltaTime*a);


	}
}
