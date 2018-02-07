using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGesture : MonoBehaviour {

	public GameObject heartone;
	public GameObject hearttwo;
	public GameObject hearttree;


	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerController.currentHealth < 150 && PlayerController.currentHealth >= 100) {

			heartone.SetActive (true);
			hearttwo.SetActive (true);
			hearttree.SetActive (false);
		
		} else if (PlayerController.currentHealth < 100 && PlayerController.currentHealth >= 50) {
		
			heartone.SetActive (true);
			hearttwo.SetActive (false);
			hearttree.SetActive (false);
		} else if (PlayerController.currentHealth < 50) {
		
			heartone.SetActive (false);
			hearttwo.SetActive (false);
			hearttree.SetActive (false);
		
		} else {
		
			heartone.SetActive (true);
			hearttwo.SetActive (true);
			hearttree.SetActive (true);
		
		
		}
		
	}
}
