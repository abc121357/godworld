﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
	public GameObject player;
	public float OffSetX = 0f;
	public float OffSetY = 25f;

	Vector3 cameraposition;

	void LastUpdate(){
	
		cameraposition.x = player.transform.position.x; // + OffSetX;
			cameraposition.y = player.transform.position.y; //+ OffSetY;
		transform.position = cameraposition;
	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
