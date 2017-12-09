using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// abc 코딩
public class MovingStar : MonoBehaviour {
    public int Min=0; // x좌표 이동최소구간
    public int Max=0; // x좌표 이동최대구간
    GameObject player;
    public int Speed = 5;

    void OnTrrigerEnter2D(Collider2D other)
    {
        player.transform.position = new Vector2(100, 2.63f);
        movement.life -= 1; //이건 말안해도 알겠죠
    }

    void OnTrrigerStay2D(Collider2D other)
    {
        Speed = Speed * 2;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Min >= transform.position.x)
        {
            if(Min >= transform.position.x||Max > transform.position.x)

                transform.Translate(Vector2.right * Speed * Time.deltaTime); // MIn에도달시 +x좌표이동
          
        }
        else if (Max <= transform.position.x)
        {
           if(Max <= transform.position.x || Min < transform.position.x)
                transform.Translate(Vector2.left * Speed * Time.deltaTime); // Max에도달시 -x좌표이동
           
        }
	}
}
