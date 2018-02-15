using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour {


	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public float timer = 1f ;
	private Animator anim ;
	public const int maxHealth = 100;
	public static int currentHealth = maxHealth; 
	public static bool activate ;
	public GameObject player;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		activate = false;

		
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if (timer < 0 && activate ==true) {

			anim.Play ("Attack");

			timer = 0.7f;

			var bullet = (GameObject)Instantiate (

				            bulletPrefab,
				            bulletSpawn.position,
				            bulletSpawn.rotation);

			if (player.GetComponent<PlayerController> ().primacurva == true) {

				bullet.GetComponent<Rigidbody> ().AddRelativeForce (-50f, 0f, 0f, ForceMode.Impulse);
				
			} else {

				bullet.GetComponent<Rigidbody> ().AddRelativeForce (0f, 0f, -50f, ForceMode.Impulse);
			
			}






			Destroy (bullet, 3.0f);
		}

		
	}


	public void TakeDamage(int amount) {

		currentHealth -= amount; 

		if (currentHealth <= 0) { 

			currentHealth = 0;

			Destroy (this.gameObject);
		}
	}


	
	
	
	
	}

