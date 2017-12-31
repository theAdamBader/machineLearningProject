using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public const int maxPlayerHealth = 100;
	public int currenPlayertHealth = maxPlayerHealth;

	//Public void damagePlayerTaken allows it to be used on other scripts (used on PlayerHurt.cs)
	public void damagePlayerTaken (int amount){

		currenPlayertHealth -= amount;

		if (currenPlayertHealth <= 0) {

			//If players's health reaches zero then "add gameState later"
			Debug.Log("Dead...");

		}
	}
}
