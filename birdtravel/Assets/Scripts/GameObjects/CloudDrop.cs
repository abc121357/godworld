using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDrop : MonoBehaviour
{
//	Vector3 playerPosition;
	//public GameObject player;
	public int speed = 10;
    private bool isDroping = false;
    public float triggerOffset = 1f;
    void OnTriggerEnter2D(Collider2D other)
	{

        movement.Die();
		
	}
    
    // Use this for initialization
    void Start()
	{

//		playerPosition = new Vector3 (87, 5.7f); // abc : 여기에 오면 구름 추락
	}

	// Update is called once per frame
	void Update()
	{
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            if (isDroping)
            {

                transform.Translate(Vector2.down * speed * Time.deltaTime);

            }
            else if (((player.transform.position.x+0.5) - transform.position.x <= triggerOffset) &&
               ((transform.position.x+0.5) - player.transform.position.x <= triggerOffset))
            {
                isDroping = true;
            }

        }




    }
}
