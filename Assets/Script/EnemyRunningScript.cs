using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunningScript : MonoBehaviour {


	public const int maxHealth = 100;
	public static int currentHealth = maxHealth; 
	private Animator anim;
	CharacterController controller;
	private Rigidbody rb;
	public float gravity = 5.0F;
	private Vector3 moveDirection;
	private float speed = -0.2f;
	public float verticalVelocity = 1.5f;




	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		controller = rb.GetComponent<CharacterController> ();

		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		verticalVelocity -= gravity * Time.deltaTime;
		moveDirection = new Vector3 (0f, 0f , speed);
		anim.SetBool ("Player", true);
        controller.Move (moveDirection);


		
		

		
	}

	public void TakeDamage(int amount) {

		currentHealth -= amount; 

		if (currentHealth <= 0) { 

			currentHealth = 0;

			Destroy (this.gameObject);
		}
	}



		public static int damage = 25;

		void OnCollisionEnter(Collision coll){


			var hit = coll.gameObject;

			if(hit.CompareTag("Giocatore")){

			hit.GetComponent<PlayerController> ().TakeDamage (damage);
            Destroy(this.gameObject);


        }

		}

}
