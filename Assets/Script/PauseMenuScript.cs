﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {

	public GUIStyle stileBottoni;
	public GUIStyle stileBottoni2;
	
	void Start(){

	
	}

	void OnGUI ()
	{

		if (PlayerController.pause) {
			GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 200, 300, 500));

			GUILayout.TextField ("", stileBottoni2);

			if (true) {


				if (GUILayout.Button ("Continua", stileBottoni)) {

					UIController.deactivate = true;
					PlayerController.pause = false;

				}
				;
				if (GUILayout.Button ("Riavvia", stileBottoni)) {
					Scene x;
					PlayerController.pause = false;
					x = SceneManager.GetActiveScene ();
					SceneManager.LoadScene (x.path);


				}
				;

				if (GUILayout.Button ("Menu Principale", stileBottoni)) {
					
					UIController.deactivate = true;
					PlayerController.pause = false;
					SceneManager.LoadScene ("Menuprincipale");

				}
				;

	
				GUILayout.EndArea ();


			}
		}
	}
}
