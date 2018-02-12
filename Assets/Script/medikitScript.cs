using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medikitScript : MonoBehaviour {


	void OnCollisionEnter(Collision coll){
	
		var hit = coll.gameObject;

		if (hit.CompareTag ("Giocatore")) {
		
			hit.GetComponent<PlayerController> ().Restore ();

			Destroy (this.gameObject);
			
		
		
		}
	
	
	
	}


}
