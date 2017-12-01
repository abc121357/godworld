using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multymoving : MonoBehaviour {
public Transform pTransform;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position == pTransform.position)//조건에 맞는지 여부를 검사합니다. 여기서는 두오브젝트의 위치가 같은지 검사합니다. 
		{ 
			transform.parent = pTransform; //오브젝트의 페어런트를 pTransform으로 지정하여 줍니다. 
		} 

	}
}
