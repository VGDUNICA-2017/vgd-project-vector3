using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadMorteScript : MonoBehaviour {

	public AudioSource death;

	void OnTriggerEnter(){
	
		death.Play ();
	
	}

}
