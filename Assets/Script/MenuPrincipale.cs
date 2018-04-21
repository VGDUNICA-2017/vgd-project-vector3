using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipale : MonoBehaviour {

	public GUIStyle stileBottoni1;
	public GUIStyle stileBottoni;

	public GUIStyle stileBottoni2;
	public GUIStyle stileBottoni3;
	private bool menuprincipale;
	private bool menuOpzioni;
	private bool caricaPartita;
	public static int score1 = 0;
	public static int score2 = 0;
	public static int score3 = 0;



	void Start(){

		menuprincipale = true;
		//PlayerPrefs.SetFloat ("ScoreLivello1", 0);
		menuOpzioni = false;
	
	}



	void OnGUI(){

		GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 200, 300, 300));



	
		if (GUILayout.Button ("Best score : " +  PlayerPrefs.GetFloat("ScoreLivello2").ToString() + "\n"  +"Inizia!", stileBottoni1)) {

			Application.LoadLevel ("Livello2");


		};


	
	
	

	
		GUILayout.EndArea ();

		GUILayout.BeginArea (new Rect (Screen.width / 2 + 150, Screen.height / 2 - 200, 300, 300));




		if(GUILayout.Button ("Best score : " +  PlayerPrefs.GetFloat("ScoreLivello3").ToString() + "\n"  +"Inizia!", stileBottoni2)){

			Application.LoadLevel ("Level01");


		};






		GUILayout.EndArea ();

		GUILayout.BeginArea (new Rect (Screen.width / 2 - 450, Screen.height / 2 - 200, 300, 300));


		if (GUILayout.Button ("Best score : " +  PlayerPrefs.GetFloat("ScoreLivello1").ToString() + "\n"  +"Inizia!",  stileBottoni3)) {


			Application.LoadLevel ("Livello1");

		};



		GUILayout.EndArea ();


		GUILayout.BeginArea (new Rect (Screen.width / 2 - 200, Screen.height / 2 + 150, 500, 500));

		if (menuprincipale) {


			/**if (GUILayout.Button ("Scegli Livello", stileBottoni)) {
				menuprincipale = false;
				caricaPartita = true;
			
			};**/

			if (GUILayout.Button ("Opzioni", stileBottoni)) {
				menuprincipale = false;
				menuOpzioni = true;
			
			};
			GUILayout.Button ("Credits", stileBottoni);

			if (GUILayout.Button ("Esci", stileBottoni)) {

				Application.Quit ();
		
			}
			;
	
		}

		if (menuOpzioni) {
		
		
		
			GUILayout.Button ("Audio", stileBottoni);
			GUILayout.Button ("Difficoltà", stileBottoni);
			if (GUILayout.Button ("Indietro", stileBottoni)) {

				menuOpzioni = false;
				menuprincipale = true;

			}
		
		
		
		}

		if (caricaPartita) {


	

			if (GUILayout.Button ("Indietro", stileBottoni)) {


				caricaPartita = false;
				menuprincipale = true;
				menuOpzioni = false;

			};




		
		
		
		}
		GUILayout.EndArea ();
	
	
	}


}


