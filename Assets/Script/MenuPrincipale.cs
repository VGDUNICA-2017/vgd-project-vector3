using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private bool menuDifficolta;
	private bool caricaPartita;
	public static int score1 = 0;
	public static int score2 = 0;
	public static int score3 = 0;
	private AudioSource audio;


	void Start(){

		menuprincipale = true;
		//PlayerPrefs.SetFloat ("ScoreLivello1", 0);
		menuOpzioni = false;
		 audio = GetComponent<AudioSource> ();
		menuOpzioni = false;
		menuComandi = false;
		menuCredits = false;
		menuDifficolta = false;

	
	}



	void OnGUI(){

		if (menuComandi == false && menuCredits==false) {
			
			GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 200, 300, 300));



	
			if (GUILayout.Button ("Best score : " + PlayerPrefs.GetFloat ("ScoreLivello2").ToString () + "\n" + "Inizia!", stileBottoni1)) {

				audio.Play ();
				Application.LoadLevel ("Livello2");


			}
			;

			GUILayout.EndArea ();

			GUILayout.BeginArea (new Rect (Screen.width / 2 + 150, Screen.height / 2 - 200, 300, 300));




			if (GUILayout.Button ("Best score : " + PlayerPrefs.GetFloat ("ScoreLivello3").ToString () + "\n" + "Inizia!", stileBottoni2)) {
				audio.Play ();
				Application.LoadLevel ("Level01");


			}
			;






			GUILayout.EndArea ();

			GUILayout.BeginArea (new Rect (Screen.width / 2 - 450, Screen.height / 2 - 200, 300, 300));


			if (GUILayout.Button ("Best score : " + PlayerPrefs.GetFloat ("ScoreLivello1").ToString () + "\n" + "Inizia!", stileBottoni3)) {

				audio.Play ();
				Application.LoadLevel ("Livello1");

			}
			;



			GUILayout.EndArea ();

		} else if (menuComandi) {
		
			GUILayout.BeginArea (new Rect (Screen.width / 2, Screen.height / 2, 1000, 400));


		

			GUILayout.Label ("", stileBottoni4);

			GUILayout.EndArea ();

		
		
		
		
		} else if (menuCredits) {
		
			GUILayout.BeginArea (new Rect (Screen.width / 2, Screen.height / 2, 1000, 400));




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
					menuOpzioni = true;

					menuDifficolta = false;
				}
				if (GUILayout.Button ("Medio", stileBottoni)) {
					audio.Play ();
					PlayerPrefs.SetFloat ("PlayerSpeed", 0.4f);
					menuOpzioni = true;

					menuDifficolta = false;

				}
				if (GUILayout.Button ("Difficile", stileBottoni)) {
					audio.Play ();
					PlayerPrefs.SetFloat ("PlayerSpeed", 0.5f);
					menuOpzioni = true;

					menuDifficolta = false;
				}
				if (GUILayout.Button ("Indietro", stileBottoni)) {
					audio.Play ();
					menuOpzioni = true;

					menuDifficolta = false;
				}

			
			
			
			}else
				if (menuOpzioni) {
					
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
			}else {


				if (GUILayout.Button ("Opzioni", stileBottoni)) {
					audio.Play ();
					menuOpzioni = true;
			
				}
				;
				GUILayout.Button ("Credits", stileBottoni);

				if (GUILayout.Button ("Esci", stileBottoni)) {
					audio.Play ();
					Application.Quit ();
		
				}
				;
	
			}
		}



		if (caricaPartita) {


	

			if (GUILayout.Button ("Indietro", stileBottoni)) {

				audio.Play ();
				caricaPartita = false;
				menuprincipale = true;
				menuOpzioni = false;

			};




		
		
		
		}
		GUILayout.EndArea ();
	
	
	}


}


