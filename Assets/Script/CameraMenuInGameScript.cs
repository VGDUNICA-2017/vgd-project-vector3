using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuInGameScript : MonoBehaviour {
	public GUIStyle stileBottoni;
	public static bool startgame = true;
	private bool game = true;
	private bool count = false;
	private float time = 7.0f;
	public GameObject player;



	void OnGUI(){
		 

		GUILayout.BeginArea (new Rect (Screen.width / 2 - 150, Screen.height / 2 - 150, 900, 1150));

		if (startgame) {

			PlayerController.pause = false;


			if (game) {

				player.SetActive (false);

				if (GUILayout.Button ("START", stileBottoni)) {


					count = true;
					game = false;


				}
			} else if (count) {




				time -= Time.deltaTime;

				if (time > 5 ) {
					GUILayout.Button ("3", stileBottoni);
				}else 
					if(time > 3 && time < 5 ){
					GUILayout.Button ("2", stileBottoni);	
				
				}else
					if(time > 1 && time<3 ){
					GUILayout.Button ("1", stileBottoni);	

					}else{

						PlayerController.setPalyer = true;
							player.SetActive(true);
						Destroy (this);

				}
			
			}
			;


		}

		GUILayout.EndArea ();
	}
}
