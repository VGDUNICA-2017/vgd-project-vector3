using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemicoSecondoLivello : MonoBehaviour {

	public static bool activate;
	private Animator anim;

	private int currentHealth;

	// Use this for initialization
	void Start () {
		activate = false;
		anim = GetComponent<Animator>();

		currentHealth = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (activate == true) {
		
		
			anim.SetBool ("activate", true);
		
		
		
		}
		
	}

	void OnCollisionEnter(Collision collision)
	{

		var hit = collision.gameObject;
	
		if (hit.CompareTag("Bullet")){


			this.TakeDamage(100);
		}

		if (hit.CompareTag ("Giocatore")) {
		
		
			this.TakeDamage(100);
		
		}


	
	
	}


	public void TakeDamage(int amount) {
		

		double timer = 1.5;
		currentHealth -= amount; 

		if (currentHealth <= 0) {

			anim.SetBool ("Death", true);
			timer -= Time.deltaTime;
			currentHealth = 0;


			if (timer <= 0) {
				Destroy (this.gameObject);
			}
			
			}
			}
}
