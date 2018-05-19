using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipale : MonoBehaviour {

	public GUIStyle stileBottoni1;
	public GUIStyle stileBottoni;
	public GUIStyle stileBottoni2;
	public GUIStyle stileBottoni3;
	public GUIStyle stileBottoni4;
	public GUIStyle stileBottoni5;
	private bool menuprincipale;
	private bool menuOpzioni;
	private bool menuComandi;
	private bool menuCredits;
	private bool menuBase;
	private bool menuDifficolta;
	private bool caricaPartita;
	public static int score1 = 0;
	public static int score2 = 0;
	public static int score3 = 0;
	private new AudioSource audio;


	void Start(){

		menuprincipale = true;
		//PlayerPrefs.SetFloat ("ScoreLivello1", 0);
		menuOpzioni = false;
		audio = GetComponent<AudioSource> ();
		menuOpzioni = false;
		menuComandi = false;
		menuCredits = false;
		menuDifficolta = false;
		menuBase = true;
		PlayerPrefs.SetFloat ("PlayerSpeed", 0.4f);
		PlayerPrefs.SetFloat ("VerticalVelocity", 0.2f);
		PlayerPrefs.SetFloat ("JumpSpeed", 0.7f);
		PlayerPrefs.SetFloat ("LateralVelocity", 0.1f);

	}



	void OnGUI(){

		if (menuComandi == false && menuCredits==false) {

			GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 200, 300, 300));




			if (GUILayout.Button ("Best score : " + PlayerPrefs.GetFloat ("ScoreLivello2").ToString () + "\n" + "Inizia!", stileBottoni1)) {

				audio.Play ();
				SceneManager.LoadScene ("Livello2");


			}
			;

			GUILayout.EndArea ();

			GUILayout.BeginArea (new Rect (Screen.width / 2 + 150, Screen.height / 2 - 200, 300, 300));




			if (GUILayout.Button ("Best score : " + PlayerPrefs.GetFloat ("ScoreLivello3").ToString () + "\n" + "Inizia!", stileBottoni2)) {
				audio.Play ();
				SceneManager.LoadScene ("Level01");


			}
			;






			GUILayout.EndArea ();

			GUILayout.BeginArea (new Rect (Screen.width / 2 - 450, Screen.height / 2 - 200, 300, 300));


			if (GUILayout.Button ("Best score : " + PlayerPrefs.GetFloat ("ScoreLivello1").ToString () + "\n" + "Inizia!", stileBottoni3)) {

				audio.Play ();
				SceneManager.LoadScene ("Livello1");

			}
			;



			GUILayout.EndArea ();

		} else if (menuComandi) {

			GUILayout.BeginArea (new Rect (Screen.width / 2- 500, Screen.height / 2 - 350, 1000, 600));




			GUILayout.Label ("", stileBottoni4);

			GUILayout.EndArea ();



		} else if (menuCredits) {

			GUILayout.BeginArea (new Rect (Screen.width / 2- 350 ,Screen.height / 2 - 350, 1000, 600));




			GUILayout.Label ("", stileBottoni5);

			GUILayout.EndArea ();








		}
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 200, Screen.height / 2 + 150, 500, 500));

		if (menuprincipale) {

			if (menuDifficolta) {

				menuOpzioni = false;
				if (GUILayout.Button ("Facile", stileBottoni)) {
					audio.Play ();
					PlayerPrefs.SetFloat ("PlayerSpeed", 0.3f);
					PlayerPrefs.SetFloat ("VerticalVelocity", 0.3f);
					PlayerPrefs.SetFloat ("JumpSpeed", 0.8f);
					PlayerPrefs.SetFloat ("LateralVelocity", 0.15f);
					menuOpzioni = true;

					menuDifficolta = false;
				}
				if (GUILayout.Button ("Medio", stileBottoni)) {
					audio.Play ();
					PlayerPrefs.SetFloat ("PlayerSpeed", 0.4f);
					PlayerPrefs.SetFloat ("VerticalVelocity", 0.2f);
					PlayerPrefs.SetFloat ("JumpSpeed", 0.7f);
					PlayerPrefs.SetFloat ("LateralVelocity", 0.1f);
					menuOpzioni = true;

					menuDifficolta = false;

				}
				if (GUILayout.Button ("Difficile", stileBottoni)) {
					audio.Play ();
					PlayerPrefs.SetFloat ("PlayerSpeed", 0.45f);
					PlayerPrefs.SetFloat ("VerticalVelocity", 0.2f);
					PlayerPrefs.SetFloat ("JumpSpeed", 0.65f);
					PlayerPrefs.SetFloat ("LateralVelocity", 0.15f);
					menuOpzioni = true;

					menuDifficolta = false;
				}
				if (GUILayout.Button ("Indietro", stileBottoni)) {
					audio.Play ();
					menuOpzioni = true;

					menuDifficolta = false;
				}




			} else if (menuOpzioni) {

				if (GUILayout.Button ("Difficoltà", stileBottoni)) {

					audio.Play ();
					menuDifficolta = true;
					menuOpzioni = false;
				}


				if (GUILayout.Button ("Indietro", stileBottoni)) {
					audio.Play ();
					menuOpzioni = false;
					menuprincipale = true;

				}
			} else if (menuBase) {


				if (GUILayout.Button ("Opzioni", stileBottoni)) {
					audio.Play ();
					menuOpzioni = true;

				}
				;
				if (GUILayout.Button ("Comandi", stileBottoni)) {
					audio.Play ();
					menuComandi = true;
					menuBase = false;

				}
				;
				if (GUILayout.Button ("Credits", stileBottoni)) {

					menuCredits = true;
					menuBase = false;

				};

				if (GUILayout.Button ("Esci", stileBottoni)) {
					audio.Play ();
					Application.Quit ();

				}
				;

			} else if (menuComandi || menuCredits) {

				if (GUILayout.Button ("Indietro", stileBottoni)) {
					audio.Play ();
					menuBase = true;
					menuComandi=false;
					menuCredits = false;
				}

			}
		}



		GUILayout.EndArea ();


	}


}


