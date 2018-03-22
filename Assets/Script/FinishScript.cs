using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour {

	public GUIStyle stileBottoni;
	private float time = 20f; 


	void OnGUI(){


		GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 350, 900, 1150));
		time-= Time.deltaTime;
		string score = ScoreManager.score.ToString();




			GUILayout.Box ("Score: " + score, GUILayout.Width(300));
			time -= Time.deltaTime;

	
			
			if (GUILayout.Button ("Menu Principale", stileBottoni)) {

				SceneManager.LoadScene ("Menuprincipale");
		
			}


		GUILayout.EndArea ();
	}
}
