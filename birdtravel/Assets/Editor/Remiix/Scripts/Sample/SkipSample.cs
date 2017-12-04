using UnityEngine;
using System.Collections;
using Remiix.Skip;

// Remiix.Skip in "/Assets/Editor/Remiix/Scripts/SkipAttribute"

namespace SampleProject_Remiix
{
	[SkipFakeMethod]
	public class EnemyAttack : MonoBehaviour
	{
		public float timeBetweenAttacks = 0.5f;
		public int attackDamage = 10;

		Animator anim;
		GameObject player;
		bool playerInRange;
		float timer;


		[SkipStringEncryption]
		void Awake ()
		{
			player = GameObject.FindGameObjectWithTag ("Player");
			anim = GetComponent <Animator> ();
		}

		[SkipRename]
		void OnTriggerEnter (Collider other)
		{
			if (other.gameObject == player) {
				playerInRange = true;
			}
		}

		[SkipAll]
		void OnTriggerExit (Collider other)
		{
			if (other.gameObject == player) {
				playerInRange = false;
			}
		}

		void Update ()
		{
			timer += Time.deltaTime;
			if (timer >= timeBetweenAttacks && playerInRange) {

				Attack ();
			}

			anim.SetTrigger ("PlayerDead");
			
		}

		void Attack ()
		{
			timer = 0f;

		}
	}
}