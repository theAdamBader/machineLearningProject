using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public const int maxHealth = 100;
	public int currentHealth = maxHealth;

	//Public void damageTaken allows it to be used on other scripts (used on PlayerHurt.cs)
	public void damageTaken (int amount){

		currentHealth -= amount;

		if (currentHealth <= 0) {

			//If players's health reaches zero then "add gameState later"
			Debug.Log("Dead...");

		}
	}
}
