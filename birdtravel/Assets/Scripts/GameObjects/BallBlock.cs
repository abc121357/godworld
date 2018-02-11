using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > 20)
            transform.position = new Vector2(transform.position.x+1, 19.5f);
        if (transform.position.y < 4)
            transform.position=new Vector2(transform.position.x,5.5f);


	}
}
