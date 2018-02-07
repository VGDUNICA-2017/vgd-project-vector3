using UnityEngine;

public class Coin : MonoBehaviour {

	Rigidbody rb;




	void Awake(){

		rb = GetComponent<Rigidbody> ();


	}

	void OnTriggerEnter(Collider other){


		Destroy (this.gameObject);






	}

}
