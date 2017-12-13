using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingStar : MonoBehaviour
{
    private Vector2 direction = Vector2.left;
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

        if (transform.localPosition.x < minPoint)
        {



            direction = Vector2.right;
        }
        else if (transform.localPosition.x > maxPoint)
        {

            direction = Vector2.left;
        }
        transform.Translate(speed * Time.deltaTime * direction);



    }
}
