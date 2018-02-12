using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyRunner : MonoBehaviour {


	public GameObject enemyRunnerPrefab;
	public Transform enemySpawn;
	private int timerRunner = 0;

	void OnCollisionEnter(Collision other){
	
		
			if (timerRunner <= 0) {

				timerRunner = 3;

				var enemyrunner = (GameObject)Instantiate (

					enemyRunnerPrefab,
					enemySpawn.position,
					enemySpawn.rotation);



				enemyrunner.GetComponent<Rigidbody> ().AddForce (0f, 0f, -1f, ForceMode.Acceleration);



		
		
		
		}
	
	
	
	
	}
}
