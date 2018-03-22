using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	public GameObject pause;
	public GameObject finish;
	public Canvas gameMenu;
	public static bool deactivate;


	// Use this for initialization
	void Start () {
		deactivate = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKeyDown (KeyCode.Escape)) {

			pause.SetActive (true);
			PlayerController.pause = true;
			deactivate = false;

		
		
		} else 
			if(deactivate==true){
		
				pause.SetActive (false);
				PlayerController.pause = false;
		
		}

		if (PlayerController.menuFine.Equals (true)) {
		
			finish.SetActive (true);
		
		}
		
	}
}
