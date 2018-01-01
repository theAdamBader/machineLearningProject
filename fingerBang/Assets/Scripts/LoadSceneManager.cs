/*
REFERENCE
	Menu UI: https://youtu.be/FrJogRBSzFo
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour {

	public void StartButton(string levelOne){

		SceneManager.LoadScene (levelOne);
	}

	public void ExitButton(string exitGame){

		Application.Quit ();
	}
}
