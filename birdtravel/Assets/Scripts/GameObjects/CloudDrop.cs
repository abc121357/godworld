using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDrop : MonoBehaviour
{
//	Vector3 playerPosition;
	public GameObject player;
	public int speed = 10;
    private bool isDroping = false;
    public float triggerOffset = 1f;
    void OnTriggerEnter2D(Collider2D other)
	{

		player.transform.position = new Vector2(0, 2.63f);
		movement.life -= 1; //abc:라이프감소

	}

    private void Reset()
    {
        
    }
    // Use this for initialization
    void Start()
	{

//		playerPosition = new Vector3 (87, 5.7f); // abc : 여기에 오면 구름 추락
	}

	// Update is called once per frame
	void Update()
	{
     	if (isDroping) {

			transform.Translate(Vector2.down * speed * Time.deltaTime);

		}else if ((player.transform.position.x - transform.position.x <= triggerOffset)&&
            (transform.position.x  - player.transform.position.x  <= triggerOffset )){
            isDroping = true;
        }
	



	}
}
