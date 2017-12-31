/*
REFERENCE:
	Particle System: https://answers.unity.com/questions/818762/particle-effect-on-enemy-death.html
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public GameObject deathEffect;
	public const int maxHealth = 30;
	public int currentHealth = maxHealth;

	//Public void damageTaken allows it to be used on other scripts (used on EnemyDamage.cs)
	public void damageTaken (int amount){
		
		currentHealth -= amount;

		if (currentHealth <= 0) {

			var death = Instantiate (deathEffect, transform.position, transform.rotation);

			//If enemy's health reaches zero then destroy the enemy
			Destroy (gameObject);

			//When enemy destroyed then activate particle
			Destroy (death.gameObject, 1f);
		}
	}
}
