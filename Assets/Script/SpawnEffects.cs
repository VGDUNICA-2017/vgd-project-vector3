using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffects : MonoBehaviour {

	public GameObject effectPrefab;
	public Transform spawnPoint;

	void OnCollisionEnter(Collision other){
	
		var effect = (GameObject)Instantiate (

			effectPrefab,
			spawnPoint.position,
			spawnPoint.rotation);
		
	
	}

}
