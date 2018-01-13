using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSurface : MonoBehaviour {
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
            maxPoint = transform.localPosition.x + endPoint;
            minPoint = transform.localPosition.x + startPoint;
        }
        else
        {
            minPoint = transform.localPosition.x + endPoint;
            maxPoint = transform.localPosition.x + startPoint;
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
