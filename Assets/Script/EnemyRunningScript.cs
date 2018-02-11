using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunningScript : MonoBehaviour {


	public const int maxHealth = 100;
	public static int currentHealth = maxHealth; 
	public static bool activate ;
	private Animator anim;
	CharacterController controller;
	private Rigidbody rb;
	private Vector3 moveDirection;
	public float speed;
	public float  timer;



	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		activate = false;
		controller = rb.GetComponent<CharacterController> ();
		moveDirection = new Vector3 (0f, 0f, speed);

		
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
	
		if (activate == true && timer <= 0) {
		
			anim.SetBool ("Player", true);

			controller.Move (moveDirection);


		
		
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
