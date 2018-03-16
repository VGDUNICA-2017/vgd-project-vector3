using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour {

	private bool destroy;
	private float timer;

	void Start(){

		destroy = false;
		timer = 1.2f;
	
	}

	void FixedUpdate(){
	
		if (destroy == true) {
		
			timer -= Time.deltaTime;

			if (timer <= 0) {

			
				Destroy (this.gameObject);
				this.GetComponent<DestroyEffect> ().SetBool(true);
			
			}
		
		
		}
	
	
	
	}

	void OnCollisionEnter(Collision coll){
	
		var hit = coll.gameObject;

		if(hit.CompareTag("Giocatore")){
			destroy=true;



		}
	
	
	
	}
}
