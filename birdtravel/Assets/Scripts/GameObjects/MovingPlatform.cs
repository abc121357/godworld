using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    private Vector2 direction = Vector2.up;
    public float speed = 5;
    // Use this for initialization

    public float endPoint; // = 4.85f;
    public float startPoint; // -0.85f

    private float minPoint; //최소값
    private float maxPoint; // 최대값
    void Start()
    {
        if (endPoint > startPoint)
        {
            maxPoint = endPoint;
            minPoint = startPoint;
        }
        else
        {
            minPoint = endPoint;
            maxPoint = startPoint;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.localPosition.y < minPoint)
        {



            direction = Vector2.up;
        }
        else if (transform.localPosition.y > maxPoint)
        {
            transform.position = new Vector3(transform.localPosition.x, minPoint,transform.localPosition.z);
//            transform.position.y = minPoint;
            //direction = Vector2.down;
        }
        transform.Translate(speed * Time.deltaTime * direction);



    }
}
