using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBall : MonoBehaviour {
    public float speed = 300f;
    public float pivotOffsetX = 0f;
    public float pivotOffsetY = 0f;
    private Vector3 pivot;
    public GameObject player;
   // public GameObject Ball;
    // Use this for initialization

        void OnTriggerEnter2D(Collider2D other)
    {
        player.transform.position = new Vector2(0, 2.63f); // abc : 공에 닿을시 0,2.63f좌표로 이동후
        movement.life -= 1; //abc:목숨감소
    }

    void Start () {
        pivot = new Vector3();
        pivot.x = transform.position.x + pivotOffsetX;
        pivot.y = transform.position.y + pivotOffsetY;
        pivot.z = transform.position.z;

    }

    // Update is called once per frame
    void Update (){
        
        float angle = Mathf.Atan2(pivot.x, pivot.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
      //  transform.Rotate( Vector3.forward, Time.deltaTime * speed);
        transform.RotateAround(pivot, Vector3.forward, Time.deltaTime * speed);
	}
}
