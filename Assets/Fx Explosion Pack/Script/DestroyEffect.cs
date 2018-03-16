using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	private bool destroy = false;

	void Start(){
	
	
		destroy = false;
	
	
	}
	void FixedUpdate ()
	{

		if (this.destroy) {
			Destroy (transform.gameObject);
		}
	
	}

	public void SetBool(bool x){

		destroy = x;

	}
}
