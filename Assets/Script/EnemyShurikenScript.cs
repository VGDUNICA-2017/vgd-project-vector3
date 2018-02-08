using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShurikenScript : MonoBehaviour {

	public static int damage = 50;

	void OnCollisionEnter(Collision coll){
	
	
		var hit = coll.gameObject;

		if(hit.CompareTag("Giocatore")){

			hit.GetComponent<PlayerController> ().TakeDamage (50);


		}
	
	}
}
