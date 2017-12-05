using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item2 : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D _soda)
	{
		if (_soda.gameObject.name == "Soda") {
			Destroy (_soda.gameObject);
		}



	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
