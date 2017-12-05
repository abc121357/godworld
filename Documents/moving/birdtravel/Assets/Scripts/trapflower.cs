using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapflower : MonoBehaviour {

    void OntriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            /*move04.speed = 10f;
            move15.speed = 10f;
            moveM13.speed = 10f;
            moveS21.speed = 10f;
        */}
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
