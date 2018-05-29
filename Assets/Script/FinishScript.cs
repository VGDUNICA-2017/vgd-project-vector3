using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour {
	private new AudioSource audio;
	public GUIStyle stileBottoni;
	public GUIStyle stileBottoni2;
	private float time = 20f; 
	Scene activeScene;
	string score;
	string nome;

	void Start(){
		audio = GetComponent<AudioSource> ();
		activeScene = SceneManager.GetActiveScene ();
		nome = activeScene.name;
	

	}


	void OnGUI(){


		GUILayout.BeginArea (new Rect (Screen.width / 2 - 300, Screen.height / 2 - 350, 900, 1150));
		time-= Time.deltaTime;
		if (nome.Equals ("Level01")) {

			score = (PlayerPrefs.GetFloat ("ScoreLivello1") + PlayerPrefs.GetFloat ("ScoreLivello2") + ScoreManager.score).ToString();
		
		} else {

			score = ScoreManager.score.ToString();
		}




		GUILayout.TextField ( score, stileBottoni2);


	
			time -= Time.deltaTime;

	
			
			if (GUILayout.Button ("Menu Principale", stileBottoni)) {
				audio.Play ();
				SceneManager.LoadScene ("Menuprincipale");
		
			}

		if (GUILayout.Button ("Ricomincia", stileBottoni)) {
			audio.Play ();
			PlayerController.currentHealth = 100;
			PlayerController.pause = false;
			Scene active = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (active.name);
			ScoreManager.score = 0;

		}

		Scene current;
		current = SceneManager.GetActiveScene ();
		string name = current.name;
		if (!(name.Equals ("Level01"))) {
			if ((GUILayout.Button ("Prossimo Livello", stileBottoni)) && !name.Equals ("Level01")) {
				audio.Play ();
		
				if (name.Equals ("Livello1")) {

					SceneManager.LoadScene ("Livello2");

				}

				if (name.Equals ("Livello2")) {

					SceneManager.LoadScene ("Level01");

				}



			}
		}


		GUILayout.EndArea ();
	}
}
