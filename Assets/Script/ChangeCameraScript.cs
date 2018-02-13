using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraScript : MonoBehaviour {

	public GameObject camera1;
	public GameObject camera2;

	void OnCollisionEnter(Collision coll){
	
		var hit = coll.gameObject;

		if(hit.CompareTag("Giocatore")){

			camera1.SetActive (false);
			camera2.SetActive(true);



		}
	
	
	
	
	
	}
}
