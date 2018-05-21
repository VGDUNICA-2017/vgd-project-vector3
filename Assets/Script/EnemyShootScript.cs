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
	private new CapsuleCollider collider;

	// Use this for initialization
	void Awake () {

		anim = GetComponent<Animator> ();
		activate = false;
		collider = this.GetComponent<CapsuleCollider> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if (timer < 0 && activate ==true) {

			anim.Play ("Attack");

			timer = 0.9f;

			var bullet = (GameObject)Instantiate (

				            bulletPrefab,
				            bulletSpawn.position,
				            bulletSpawn.rotation);

	

				bullet.GetComponent<Rigidbody> ().AddRelativeForce (0f, 0f, 50f, ForceMode.Impulse);
		
			Destroy (bullet, 3.0f);
		}

		
	}


	public void TakeDamage(int amount) {



		double timer = 0.5;
		currentHealth -= amount; 

		if (currentHealth <= 0) {

			collider.isTrigger = true;
			activate = false;
			anim.Play("Death");
			timer -= Time.deltaTime;
			currentHealth = 0;


			if (timer <= 0) {

				activate = false;
				Destroy (this.gameObject);
			}


		}
	}


	void OnCollisionEnter(Collision collision)
	{

		var hit = collision.gameObject;

		if (hit.CompareTag("Bullet")){


			this.TakeDamage(100);
		}




	}
}

