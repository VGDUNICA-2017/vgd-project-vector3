using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score = 0;

	Text text;


	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update () {
		text.text = "Monete del tesoro :" + score;
	}
}
