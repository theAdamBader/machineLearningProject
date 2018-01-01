/*
REFERENCE
	Score Manager: https://unity3d.com/learn/tutorials/projects/survival-shooter-tutorial/scoring-points
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;

	Text textScore;

	void Awake () {
		//Gets Text UI added with a score = 0
		textScore = GetComponent<Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Everytime enemy dies then updates score
		textScore.text = "Score: " + score;
	}
}
