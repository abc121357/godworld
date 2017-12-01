using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	int a = 1; 

	void Update() 
	{ 

	


		if (transform.localPosition.y < -2.0f) 
		{ 
			a = 1; 
		} 
		else if(transform.localPosition.y  > 2.0f) 
		{ 
			a = -1; 
		} 

		transform.Translate(Vector3.up * 5.0f * Time.deltaTime * a);
		transform.Translate(Vector3.right * 5.0f * Time.deltaTime * a);

	} 
}
