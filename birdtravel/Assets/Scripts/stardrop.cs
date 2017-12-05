using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stardrop : MonoBehaviour
{

    public GameObject player;
    static public bool trigger = false;
    float a = 1;
    int speed = 10;
    
    void OnTriggerEnter2D(Collider2D other)
    {
       
            player.transform.position = new Vector2(0, 2.63f);
        trigger = false;
        movement.life -= 1;
       
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (player.transform.position.x +0.5f > transform.position.x)
        {
            trigger = true;
        }

        if (trigger == true)
        {
            if (transform.position.y > 7)
            {
                a = 1;
            }
            if (transform.position.y < -2)
            {
                a = -1;
            }

            transform.Translate(Vector2.down * speed * Time.deltaTime*a);

        }
    }
}
