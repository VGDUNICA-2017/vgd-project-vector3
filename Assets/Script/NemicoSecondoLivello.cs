using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemicoSecondoLivello : MonoBehaviour {

	public static bool activate;
	private Animator anim;
	private new CapsuleCollider collider;

	private int currentHealth;

	// Use this for initialization
	void Awake () {
		activate = false;
		anim = GetComponent<Animator>();
		collider = this.GetComponent<CapsuleCollider> ();
		currentHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (activate == true) {
		
			currentHealth = 100;
			anim.SetBool ("activate", true);
			anim.Play ("Punch");
		
		
		
		}
		
	}

	void OnCollisionEnter(Collision collision)
	{

		var hit = collision.gameObject;
	
		if (hit.CompareTag("Bullet")){


			this.TakeDamage(100);
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
}
