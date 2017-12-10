using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDrop : MonoBehaviour
{
	Vector3 playerPosition;
	public GameObject player;
	int speed = 10;
	void OnTriggerEnter2D(Collider2D other)
	{

		player.transform.position = new Vector2(0, 2.63f);
		movement.life -= 1; //abc:라이프감소

	}


	// Use this for initialization
	void Start()
	{
		playerPosition = new Vector3 (87, 5.7f); // abc : 여기에 오면 구름 추락
	}

	// Update is called once per frame
	void Update()
	{
		if (playerPosition.x >= player.transform.position.x && playerPosition.y >=player.transform.position.y) {

			transform.Translate(Vector2.down * speed * Time.deltaTime);

		}
	



	}
}
