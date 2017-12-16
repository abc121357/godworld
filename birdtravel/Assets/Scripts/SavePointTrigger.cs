using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointTrigger : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other)
	{
        GameManager.isSaved = true;
        
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
