using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxmove : MonoBehaviour {
	public Transform pTransform ; // 원하는 이동식 물체를 인스펙터에서 지정하면 됩니다.
	// Use this for initialization


	void OnTriggerEnter2D(Collider2D _box)
	{
		if (_box.gameObject.tag == "box")
		{
			transform.parent = pTransform;
		}
	}


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
			
		} 

}
