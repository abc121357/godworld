using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move04 : MonoBehaviour {
	public int direction = 1;
    public float speed = 5;
    // Use this for initialization

    public float endPoint; // = 4.85f;
    public float startPoint; // -0.85f

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.localPosition.y > endPoint) {
			direction = -1;
		}
		else if (transform.localPosition.y < startPoint) {
			direction = 1;
		}


		transform.Translate(Vector2.up*speed*Time.deltaTime* direction);


	}
}
