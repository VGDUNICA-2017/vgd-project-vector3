using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour {


	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public float timer = 1.5f;
	private Animator anim ;
	public const int maxHealth = 100;
	public static int currentHealth = maxHealth; 
	public static bool activate ;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		activate = false;

		
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if (timer < 0 && activate ==true) {

			timer = 1.5f;
			anim.Play ("Attack");
			var bullet = (GameObject)Instantiate (

				            bulletPrefab,
				            bulletSpawn.position,
				            bulletSpawn.rotation);



			bullet.GetComponent<Rigidbody> ().AddRelativeForce (0f, 0f, -50f, ForceMode.Impulse);



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

