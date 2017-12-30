using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public const int maxHealth = 30;
	public int currentHealth = maxHealth;

	//Public void damageTaken allows it to be used on other scripts (used on EnemyDamage.cs)
	public void damageTaken (int amount){
		
		currentHealth -= amount;

		if (currentHealth <= 0) {

			//If enemy's health reaches zero then destroy the enemy
			Destroy (gameObject);

		}
	}
}
