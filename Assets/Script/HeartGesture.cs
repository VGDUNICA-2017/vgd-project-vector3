using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGesture : MonoBehaviour {

	public   GameObject heartone;
	public   GameObject hearttwo;
	public  GameObject hearttree;


	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (PlayerController.currentHealth < 150 && PlayerController.currentHealth >= 100) {

			heartone.SetActive (false);
			hearttwo.SetActive (true);
			hearttree.SetActive (true);
		
		} else if (PlayerController.currentHealth < 100 && PlayerController.currentHealth >= 50) {
		
			heartone.SetActive (false);
			hearttwo.SetActive (false);
			hearttree.SetActive (true);
		} else if (PlayerController.currentHealth < 50) {
		
			heartone.SetActive (false);
			hearttwo.SetActive (false);
			hearttree.SetActive (false);
		
		} else if (PlayerController.currentHealth == 150) {
		
			heartone.SetActive (true);
			hearttwo.SetActive (true);
			hearttree.SetActive (true);
		
		
		} else {

			heartone.SetActive (false);
			hearttwo.SetActive (false);
			hearttree.SetActive (false);

		
		
		}

	}

	public  void restart(){
	
		heartone.SetActive (true);
		hearttwo.SetActive (true);
		hearttree.SetActive (true);
	
	
	}


}
