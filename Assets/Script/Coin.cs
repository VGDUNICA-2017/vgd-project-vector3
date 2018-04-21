using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Coin : MonoBehaviour {

	Rigidbody rb;

	private new AudioSource audio;


	void Start(){


		audio = GetComponent<AudioSource> ();

	}

	void OnTriggerEnter(Collider other){

		GameObject hit = other.gameObject;

		if(hit.CompareTag("Giocatore")){
			audio.Play ();
	
		} 

		if(hit.CompareTag("Giocatore")){

		ScoreManager.score += 1;
		Destroy (this.gameObject);
		}





	}

}
