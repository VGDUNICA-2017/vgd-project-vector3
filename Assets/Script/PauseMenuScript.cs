using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {

	public GUIStyle stileBottoni;
	
	void Start(){

	
	}

	void OnGUI ()
	{
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 200, 300, 500));

		if (true) {

			if (GUILayout.Button ("PAUSA", stileBottoni)) {


			}

			if (GUILayout.Button ("Continua", stileBottoni)) {

				UIController.deactivate = true;
				PlayerController.pause = false;

			}
			;
			if (GUILayout.Button ("Riavvia", stileBottoni)) {



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
