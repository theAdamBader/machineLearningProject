/*
REFERENCE
	Health: https://unity3d.com/learn/tutorials/topics/multiplayer-networking/player-health-single-player
	Health Bar: https://www.youtube.com/watch?v=GfuxWs6UAJQ
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public const float maxPlayerHealth = 100;
	public float currenPlayertHealth = maxPlayerHealth;
	public Slider healthBar;

	void Start (){
		currenPlayertHealth = maxPlayerHealth;

		healthBar.value = calculateHealth ();
	}

	void Update(){
		
	}

	//Public void damagePlayerTaken allows it to be used on other scripts (used on PlayerHurt.cs)
	public void damagePlayerTaken (int amount){

		currenPlayertHealth -= amount;
		healthBar.value = calculateHealth ();

		if (currenPlayertHealth <= 0) {

			//If players's health reaches zero then "add gameState later"
			Debug.Log("Dead...");

		}
	}

	float calculateHealth(){
	
		return currenPlayertHealth / maxPlayerHealth;
	
	}
}
