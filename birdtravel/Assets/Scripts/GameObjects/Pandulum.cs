using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pandulum : MonoBehaviour {

    public float speed = 300f;
    public float pivotOffsetX = 0f;
    public float pivotOffsetY = 0f;
    public float rotatingOffset = 0.5f;
    private Vector3 pivot;
    private Vector3 direction = Vector3.forward;

    public GameObject player;
    // public GameObject Ball;
    // Use this for initialization


    void Start()
    {
        pivot = new Vector3();
        pivot.x = transform.position.x + pivotOffsetX;
        pivot.y = transform.position.y + pivotOffsetY;
        pivot.z = transform.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {

       
        if (transform.eulerAngles.z > rotatingOffset && transform.eulerAngles.z < 180)
        {
            Debug.Log(transform.eulerAngles.z);
            direction = Vector3.back;
        }
        else if (transform.eulerAngles.z < 360-rotatingOffset && transform.eulerAngles.z > 180)
        {

            Debug.Log(transform.eulerAngles.z);
            direction = Vector3.forward; 
        }

            transform.RotateAround(pivot,direction, Time.deltaTime * speed);
        
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //  transform.Rotate( Vector3.forward, Time.deltaTime * speed);
    }
}
