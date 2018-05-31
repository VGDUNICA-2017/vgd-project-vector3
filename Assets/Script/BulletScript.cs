using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public static int damage = 50;

	void OnCollisionEnter(Collision coll){


		var hit = coll.gameObject;

	

		if (hit.CompareTag ("EnemyRunner")) {
		
			hit.GetComponent<EnemyRunningScript> ().TakeDamage (damage);
            Destroy(this.gameObject);
		}



	}
}
