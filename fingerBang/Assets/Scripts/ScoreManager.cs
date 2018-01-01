using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;

	Text textScore;

	// Use this for initialization
	void Awake () {
		textScore = GetComponent<Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		textScore.text = "Score: " + score;
	}
}
