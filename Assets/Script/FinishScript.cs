using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour {

	public GUIStyle stileBottoni;
	public GUIStyle stileBottoni2;
	private float time = 20f; 


	void OnGUI(){


		GUILayout.BeginArea (new Rect (Screen.width / 2 - 300, Screen.height / 2 - 350, 900, 1150));
		time-= Time.deltaTime;
		string score = ScoreManager.score.ToString();


		GUILayout.TextField ( score, stileBottoni2);


	
			time -= Time.deltaTime;

	
			
			if (GUILayout.Button ("Menu Principale", stileBottoni)) {

				SceneManager.LoadScene ("Menuprincipale");
		
			}

		if (GUILayout.Button ("Ricomincia", stileBottoni)) {

			PlayerController.currentHealth = 100;
			PlayerController.pause = false;
			Scene active = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (active.name);
			ScoreManager.score = 0;

		}

		if (GUILayout.Button ("Prossimo Livello", stileBottoni)) {

			SceneManager.LoadScene ("Level01");

		}


		GUILayout.EndArea ();
	}
}
