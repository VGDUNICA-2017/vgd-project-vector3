using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipale : MonoBehaviour {

	public GUIStyle stileBottoni;
	private bool menuprincipale;
	private bool menuOpzioni;

	void Start(){

		menuprincipale = true;
		menuOpzioni = false;
	
	
	
	}

	void OnGUI(){
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 250, Screen.height / 2 - 250, 500, 500));

		if (menuprincipale) {
			
			if (GUILayout.Button ("Nuova Partita", stileBottoni)) {
		
				Application.LoadLevel ("Level01");
		
			}
			;
			GUILayout.Button ("Carica Partita", stileBottoni);

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
		GUILayout.EndArea ();
	
	
	}
}
