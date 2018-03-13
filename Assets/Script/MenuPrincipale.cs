using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipale : MonoBehaviour {

	public GUIStyle stileBottoni;
	private bool menuprincipale;
	private bool menuOpzioni;
	private bool caricaPartita;

	void Start(){

		menuprincipale = true;
		menuOpzioni = false;
	
	
	
	}

	void OnGUI(){
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 200, 350, 500));

		if (menuprincipale) {
			
			if (GUILayout.Button ("Nuova Partita", stileBottoni)) {
		
				Application.LoadLevel ("Livello1");
		
			}
			;
			if (GUILayout.Button ("Scegli Livello", stileBottoni)) {
				menuprincipale = false;
				caricaPartita = true;
			
			};

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
		
		
			GUILayout.Button ("Impostazioni", stileBottoni);
			GUILayout.Button ("Comandi", stileBottoni);
			GUILayout.Button ("Difficoltà", stileBottoni);
			if (GUILayout.Button ("Esci", stileBottoni)) {

				menuOpzioni = false;
				menuprincipale = true;

			}
		
		
		
		}

		if (caricaPartita) {


			if (GUILayout.Button ("La Foresta Rossa", stileBottoni)) {

				Application.LoadLevel ("Livello1");

			}
			;
			if(GUILayout.Button ("Borgo di Inuyama", stileBottoni)){

				Application.LoadLevel ("Livello2");


			};


			if (GUILayout.Button ("Giardino di Harumi", stileBottoni)) {
			
			
				Application.LoadLevel ("Level01");
			
			};

			if (GUILayout.Button ("Indietro", stileBottoni)) {


				caricaPartita = false;
				menuprincipale = true;
				menuOpzioni = false;

			};




		
		
		
		}
		GUILayout.EndArea ();
	
	
	}
}
