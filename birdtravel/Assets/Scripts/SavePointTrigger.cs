using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointTrigger : MonoBehaviour {
	static public bool Plag=false;

	void OnTriggerEnter2D(Collider2D other)
	{
		Plag = true; //abc:세이브포인트도달하면 세이브부터시작하게 저장

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
