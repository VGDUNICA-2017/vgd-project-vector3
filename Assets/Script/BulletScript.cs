using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public static int damage = 100;

	void OnCollisionEnter(Collision coll){


		var hit = coll.gameObject;

		if(hit.CompareTag("EnemyShooter")){

			hit.GetComponent<EnemyShootScript> ().TakeDamage (damage);


		}

	}
}
